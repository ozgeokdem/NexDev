using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;

namespace PA.NexDev.ViewComponents
{
    public class SiteFooterViewComponent : ViewComponent
    {
        private readonly NexDevDbContext _context;
        public SiteFooterViewComponent(NexDevDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _context
                .SiteSettings
                .FirstOrDefaultAsync();

            return View(model);
        }
    }
}
