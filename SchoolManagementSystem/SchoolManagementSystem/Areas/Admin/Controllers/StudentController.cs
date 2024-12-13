using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Mappers;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Models;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IClassesService _classesService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, IClassesService classesService,ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _classesService = classesService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var studentDTo = await _studentService.GetAllStudent();
            return View(studentDTo);
        }
        public async Task<IActionResult> Details(int id)
        {
            var student =await _studentService.GetStudentWithDetailsAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var classes = await _classesService.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult>  Create(StudentDTO studentDto) {

            if (ModelState.IsValid)
            {
                try
                {
                    await _studentService.CreateStudentAsync(studentDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while creating a student.");
                }
            }
            var classes = await _classesService.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName", studentDto.ClassID);
            return View(studentDto);
        }
    }
}
