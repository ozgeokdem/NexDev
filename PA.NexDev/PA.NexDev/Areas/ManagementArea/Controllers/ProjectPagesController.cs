using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class ProjectPagesController : Controller
    {
        private readonly NexDevDbContext _context;
        public ProjectPagesController(NexDevDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.ProjectPages.AsNoTracking().FirstOrDefaultAsync();

            if (model is null)
            {
                model = new ProjectPage
                {
                    Id = Guid.NewGuid(),
                    PageTitle = string.Empty,
                    PageDescription = string.Empty,
                };
                await _context.ProjectPages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.ProjectPages.FirstOrDefaultAsync();
            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectPage model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.ProjectPages.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
