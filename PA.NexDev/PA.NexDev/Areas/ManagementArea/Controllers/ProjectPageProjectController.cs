using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;
using PA.NexDev.Utils;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class ProjectPageProjectController : Controller
    {
        private readonly NexDevDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProjectPageProjectController(NexDevDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            //Guid? id = _context.ProjectPages.FirstOrDefault()?.Id;
            //var model = await _context
            //    .ProjectItems
            //    .AsNoTracking()
            //    .Where(x => x.ProjectPageId == id)
            //    .ToListAsync();

            var model = _context
                .ProjectPages
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefault()
                ?.Items
                ?.ToList();

            return View(model);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectItem model, IFormFile img)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();
            model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            model.ProjectPageId = _context.ProjectPages.FirstOrDefault()?.Id;

            model.ProjectPage = null;

            await _context.ProjectItems.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _context
                .ProjectItems
                .FindAsync(id);

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProjectItem model, IFormFile? img)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (img is not null)
            {
                if (!string.IsNullOrWhiteSpace(model.ImageUrl))
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);

                model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            }

            _context.ProjectItems.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.ProjectItems.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri Bulunamadı!" });

            if (!String.IsNullOrWhiteSpace(model.ImageUrl))
                await FileUploader.DeleteAsync(_env, model.ImageUrl);

            _context.ProjectItems.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi." });
        }
    }
}
