using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Utilities;

namespace SchoolManagementSystem.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = WebSiteRole.WebSite_Student)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
