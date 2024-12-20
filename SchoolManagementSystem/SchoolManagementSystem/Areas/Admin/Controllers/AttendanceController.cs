using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IStudentService _studentService;
        private readonly IAdvisorService _advisorService;
        private readonly ILogger<AttendanceController> _logger;
        public AttendanceController(IAttendanceService attendanceService, ILogger<AttendanceController> logger,IAdvisorService advisorService, IStudentService studentService)
        {
            _attendanceService = attendanceService;
            _studentService = studentService;
            _advisorService = advisorService;
            _logger = logger;
        }
        public async Task<ActionResult> Index()
        {
            var attendance =await _attendanceService.GetAttendancesWithDetailsAsync();
            if (attendance == null) return NotFound();
            return View(attendance);
        }

        // GET: AttendanceController/Create
        public async Task<ActionResult> Create()
        {
            var students = await _studentService.GetAllStudent();
            var advisors = await _advisorService.GetAllAdvisorAsyn();
            ViewBag.Students = new SelectList(students, "StudentID", "FirstName");
            ViewBag.Advisors = new SelectList(advisors, "AdvisorID", "FirstName");
            return View();
        }

        // POST: AttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AttendanceDTO attendanceDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _attendanceService.CreateAttendanceAsync(attendanceDTO);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating attendance.");
            }
            var students = await _studentService.GetAllStudent();
            var advisors = await _advisorService.GetAllAdvisorAsyn();
            ViewBag.Students = new SelectList(students, "StudentID", "FirstName");
            ViewBag.Advisors = new SelectList(advisors, "AdvisorID", "FirstName");
            return View(attendanceDTO);
        }

        // GET: AttendanceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttendanceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: AttendanceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttendanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
