using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Utilities;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
