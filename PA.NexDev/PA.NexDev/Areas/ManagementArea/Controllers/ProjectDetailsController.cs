using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;
using PA.NexDev.Utils;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class ProjectDetailsController : Controller
    {
        private readonly NexDevDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProjectDetailsController(NexDevDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .ProjectDetails
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (model is null)
            {
                model = new ProjectDetail();
                model.Id = Guid.NewGuid();
                await _context.ProjectDetails.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context
                .ProjectDetails
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectDetail model, IFormFile img)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (img != null)
            {
                if (!string.IsNullOrWhiteSpace(model.ImageUrl))
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);

                model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            }

            _context.ProjectDetails.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
