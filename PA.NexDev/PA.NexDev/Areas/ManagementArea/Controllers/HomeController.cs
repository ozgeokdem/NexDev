using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models;
using PA.NexDev.ViewModels;

namespace PA.NexDev.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class HomeController : Controller
    {
        private readonly NexDevDbContext _context;
        public HomeController(NexDevDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new DashboardVM()
            {
                TotalMessageCount = await _context.ContactMessages.CountAsync() +
                                    await _context.ProjectMessages.CountAsync(),

                ReadMessageCount = await _context.ContactMessages.CountAsync(x => x.IsReaded) +
                                   await _context.ProjectMessages.CountAsync(x => x.IsReaded),

                ProjectMessageCount = await _context.ProjectMessages.CountAsync(),

                ReadProjectMessageCount = await _context.ProjectMessages.CountAsync(x => x.IsReaded),

                TestimonialCount = await _context.Testimonials.CountAsync(),

                PartnerCount = await _context.HomePartners.CountAsync(),

                AdminCount = await _context.Users.CountAsync(x => x.IsAdmin),
            };
            return View(model);
        }
    }
}
