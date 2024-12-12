using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var student = await _studentService.GetAllStudent();
            return View(student);
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult>  Create(StudentDTO studentDTO) {
        
           if(ModelState.IsValid)
            {
                await _studentService.CreateStudentAsync(studentDTO);
                return RedirectToAction(nameof(Index));
            }
           return View(studentDTO);
        }
    }
}
