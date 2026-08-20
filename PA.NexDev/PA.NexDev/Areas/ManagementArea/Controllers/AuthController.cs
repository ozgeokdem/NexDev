using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using System.Security.Claims;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea")]
    public class AuthController : Controller
    {
        private readonly NexDevDbContext _context;
        public AuthController(NexDevDbContext context)
        {
            _context = context;
        }

        public ActionResult Login(string? ReturnUrl)
        {
            return View(new LoginVM { ReturnUrl = ReturnUrl });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
        {
            var user = await _context
                .Users
                .AsNoTracking()
                .Where(x => x.Email == model.Email && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user is null)
            {
                ModelState.AddModelError("Email", "Eposta veya şifre hatalı!");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.IsAdmin == true ? "Admin" : "User"),
                new Claim("LoginTime", DateTimeOffset.Now.ToUnixTimeSeconds().ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProps = new AuthenticationProperties()
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20),
                IssuedUtc = DateTimeOffset.UtcNow
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

            if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                return Redirect(model.ReturnUrl);
            else
                return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
    public class LoginVM
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
