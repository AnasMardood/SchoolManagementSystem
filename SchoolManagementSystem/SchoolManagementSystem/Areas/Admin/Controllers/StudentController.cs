using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Mappers;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Models;
using SchoolManagement.DataAccess.Utilities;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
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
                    studentDto.ClassDTO = null;
                    if (studentDto.PictureFile != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await studentDto.PictureFile.CopyToAsync(memoryStream);
                            studentDto.ProfilePicture = memoryStream.ToArray();
                        }
                    }
                    await _studentService.CreateStudentAsync(studentDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while adding the student.");
                    return View(studentDto);
                }
            }
            else {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError(error.ErrorMessage);
                    }
                }
            }
            var classes = await _classesService.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName", studentDto.ClassID);
            return View(studentDto);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentWithDetailsAsync(id); 
            if (student == null) {
                return NotFound(); 
            }
            if(student.ClassDTO == null) {
            student.ClassDTO = new ClassDTO();
            }
            var classes = await _classesService.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName", student.ClassID);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentDTO studentDto)
        {
            
            if (id != studentDto.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                studentDto.ClassDTO = null;
                if (studentDto.PictureFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await studentDto.PictureFile.CopyToAsync(memoryStream);
                        studentDto.ProfilePicture = memoryStream.ToArray();
                    }
                }
                await _studentService.EditStudentAsync(studentDto);
                return RedirectToAction(nameof(Index));
            }

            var classes = await _classesService.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName", studentDto.ClassID);
            return View(studentDto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentWithDetailsAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            var classes = await _classesService.GetAllClasses();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName");
         
            return View(student);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeletStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
