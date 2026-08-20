using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class HomePartnersController : Controller
    {
        private readonly NexDevDbContext _context;
        public HomePartnersController(NexDevDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .HomePartners
                .ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomePartner model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();

            await _context.HomePartners.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _context.HomePartners.FindAsync(id);

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, HomePartner model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.HomePartners.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.HomePartners.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri Bulunamadı!" });

            _context.HomePartners.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi." });
        }
    }
}
