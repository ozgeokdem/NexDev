using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;
using PA.NexDev.ViewModels;

namespace PA.NexDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly NexDevDbContext _context;
        public HomeController(NexDevDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .HomePages
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync();

            model.Partners = await _context
                .HomePartners
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> About()
        {
            var model = await _context
                .AboutPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            model.Testimonials = await _context
                .Testimonials
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Services()
        {
            return View(await _context
                .ServicePages
                .AsNoTracking()
                .Include(x => x.Services)
                .FirstOrDefaultAsync());
        }

        public async Task<IActionResult> Project()
        {
            var model = await _context.ProjectPages
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync();

            if (model is null)
                return NotFound();

            return View(model);
        }

        public async Task<IActionResult> Contact()
        {
            return View(await _context
                .ContactPages
                .FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Contact(string name, string email, string subject, string message)
        {
            var model = new ContactMessage
            {
                FullName = name,
                Email = email,
                Subject = subject,
                Message = message,
                SendDate = DateTimeOffset.Now,
                IsReaded = false,
                Id = Guid.NewGuid()
            };
            await _context.ContactMessages.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ProjectDetail()
        {
            var model = await _context
                .ProjectDetails
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var page = await _context
                .ProjectPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (model is null || page is null)
                return NotFound();

            var vm = new ProjectDetailVM
            {
                Page = page,
                Detail = model
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ProjectDetail(string projectname, string fullname, string email, string message)
        {
            var model = new ProjectMessage
            {
                ProjeName = projectname,
                FullName = fullname,
                Email = email,
                Message = message,
                SendDate = DateTimeOffset.Now,
                IsReaded = false,
                Id = Guid.NewGuid()
            };
            await _context.ProjectMessages.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
