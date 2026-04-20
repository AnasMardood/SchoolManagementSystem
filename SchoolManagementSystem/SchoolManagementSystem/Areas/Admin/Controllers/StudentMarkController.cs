using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Utilities;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
    public class StudentMarkController : Controller
    {
        private readonly IStudentMarkService _studentMarkService;
        private readonly IStudentService _studentService;
        private readonly IMaterialsService _materialsService;
        private readonly ILogger<StudentMarkController> _logger;


        public StudentMarkController(IStudentMarkService studentMarkService, ILogger<StudentMarkController> logger , IStudentService studentService, IMaterialsService materialsService)
        {
            _studentMarkService = studentMarkService;
            _studentService = studentService;
            _materialsService = materialsService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var Smark=await _studentMarkService.GetAllStudentMarksAsync();
            if (Smark == null) return NotFound();
            return View(Smark);
        }
        private async void ListingMaterialsandStudent()
        {
            var students = await _studentService.GetAllStudent();
            var materials = await _materialsService.GetMaterialsAsyn();
           
           
            ViewBag.Students = new SelectList(students, "StudentID", "FirstName");
            ViewBag.Materials = new SelectList(materials, "MaterialID", "LessonsName");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var students = await _studentService.GetAllStudent();
            var materials = await _materialsService.GetMaterialsAsyn();
            ViewBag.Students = new SelectList(students, "StudentID", "FirstName");
            ViewBag.Materials = new SelectList(materials, "MaterialID", "LessonsName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentMarkDTO studentMarkDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _studentMarkService.CreatetudentMarkAsync(studentMarkDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while adding the student.");
                    return View(studentMarkDto);
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError(error.ErrorMessage);
                    }
                }
            }
            ListingMaterialsandStudent();
            return View(studentMarkDto);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var Smark = await _studentMarkService.GetStudentMarkByIdAsync(id);
            if (Smark == null) return NotFound();
            var students = await _studentService.GetAllStudent();
            var materials = await _materialsService.GetMaterialsAsyn();
            ViewBag.Students = new SelectList(students, "StudentID", "FirstName");
            ViewBag.Materials = new SelectList(materials, "MaterialID", "LessonsName");
            return View(Smark);
        }

        // POST: AttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentMarkDTO studentMarkDto)
        {
            if (id != studentMarkDto.GradeID) return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentMarkService.UpdateStudentMarkAsync(studentMarkDto);
                    return RedirectToAction(nameof(Index));

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating attendance.");
            }
            ListingMaterialsandStudent();
            return View(studentMarkDto);
        }
        // GET: AttendanceController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var attendance = await _studentMarkService.GetStudentMarkByIdAsync(id);
            ListingMaterialsandStudent();
            return View(attendance);
        }

        // POST: AttendanceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentMarkService.DeleteStudentMarkAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
