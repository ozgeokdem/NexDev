using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.Models.Entities;
using PA.NexDev.Utils;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class HomePagesController : Controller
    {
        private readonly NexDevDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomePagesController(NexDevDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.HomePages.AsNoTracking().FirstOrDefaultAsync();

            if (model is null)
            {
                model = new HomePage();
                model.Id = Guid.NewGuid();
                await _context.HomePages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.HomePages.FirstOrDefaultAsync();
            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HomePage model, IFormFile img)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            ////model.Id = Guid.NewGuid();
            //model.ImageUrl = await FileUploader.UploadAsync(_env, img);

            ////await _context.HomePages.AddAsync(model);
            //_context.HomePages.Update(model);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid)
                return View(model);

            if (img != null)
            {
                if (!string.IsNullOrWhiteSpace(model.ImageUrl))
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);

                model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            }

            _context.HomePages.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
