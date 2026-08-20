using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly NexDevDbContext _context;
        public UsersController(NexDevDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Users
                .AsNoTracking()
                .ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _context
                .Users
                .FindAsync(id);

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Users.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.Users.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri Bulunamadı!" });

            _context.Users.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi." });
        }
    }
}
