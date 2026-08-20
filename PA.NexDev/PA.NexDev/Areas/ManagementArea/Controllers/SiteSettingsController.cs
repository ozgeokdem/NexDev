using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class SiteSettingsController : Controller
    {
        private readonly NexDevDbContext _context;
        public SiteSettingsController(NexDevDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .SiteSettings
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (model is null)
            {
                model = new SiteSetting();
                model.Id = Guid.NewGuid();
                await _context.SiteSettings.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context
                .SiteSettings
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SiteSetting model)
        {
            if (!ModelState.IsValid)
                return View(model);


            _context.SiteSettings.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
