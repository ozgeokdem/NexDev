using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class ProjectMessagesController : Controller
    {
        private readonly NexDevDbContext _context;
        public ProjectMessagesController(NexDevDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .ProjectMessages
                .AsNoTracking()
                .OrderBy(x => x.SendDate)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await _context
                .ProjectMessages
                .FindAsync(id);

            if (model is null)
                return RedirectToAction(nameof(Index));

            model.IsReaded = true;
            _context.ProjectMessages.Update(model);
            await _context.SaveChangesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.ProjectMessages.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri Bulunamadı!" });

            _context.ProjectMessages.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi." });
        }
    }
}
