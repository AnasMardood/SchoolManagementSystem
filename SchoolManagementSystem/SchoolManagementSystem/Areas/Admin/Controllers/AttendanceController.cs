using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Models;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IStudentService _studentService;
        private readonly IMaterialsService _materialsService;
        private readonly ILogger<AttendanceController> _logger;
        public AttendanceController(IAttendanceService attendanceService, ILogger<AttendanceController> logger,IMaterialsService materialsService, IStudentService studentService)
        {
            _attendanceService = attendanceService;
            _studentService = studentService;
            _materialsService = materialsService;
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
            ListingMaterialsandStudent();
            return View();
        }

        // POST: AttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AttendanceDTO attendanceDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    await _attendanceService.CreateAttendanceAsync(attendanceDTO);
                    return RedirectToAction(nameof(Index));
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating attendance.");
            }

            ListingMaterialsandStudent();
            return View(attendanceDTO);
        }

        // GET: AttendanceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var attendance =await _attendanceService.GetAttendancesWithDetailsAsync(id);
            if (attendance == null) return NotFound();
            ListingMaterialsandStudent();
            return View(attendance);
        }

        // POST: AttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AttendanceDTO attendanceDTO)
        {
            if (id != attendanceDTO.AttendanceID) return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                    await _attendanceService.EditAttendanceAsync(attendanceDTO);
                    return RedirectToAction(nameof(Index));

                }
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating attendance.");
            }
            ListingMaterialsandStudent();
            return View(attendanceDTO);
        }

        // GET: AttendanceController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var attendance = await _attendanceService.GetAttendancesWithDetailsAsync(id);
            ListingMaterialsandStudent();
            return View(attendance);
        }

        // POST: AttendanceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _attendanceService.DeleteAttendanceAsync(id);
            return RedirectToAction(nameof(Index));
        }
        private async void ListingMaterialsandStudent()
        {
            var students = await _studentService.GetAllStudent();
            var materials = await _materialsService.GetMaterialsAsyn();
            ViewBag.Students = new SelectList(students, "StudentID", "FirstName");
            ViewBag.Materials = new SelectList(materials, "MaterialID", "LessonsName");
        }
    }
}
