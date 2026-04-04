using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Utilities;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.StudentCount = await _context.Students.CountAsync();
            ViewBag.MaterialCount = await _context.Materials.CountAsync();
            ViewBag.UserCount = await _context.ApplicationUsers.CountAsync();
            ViewBag.AdvisorCount = await _context.Advisors.CountAsync();
            
            return View();
        }
    }
}
