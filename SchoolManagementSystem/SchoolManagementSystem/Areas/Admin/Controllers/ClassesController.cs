using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Models;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassesController : Controller
    {
        private readonly IMaterialsService _materialsService;
        private readonly IClassesService _classesService;
        private readonly ILogger<ClassesController> _logger;
        public ClassesController(IMaterialsService materialsService, ILogger<ClassesController> logger, IClassesService classesService) { 
            _materialsService = materialsService;
            _classesService = classesService;
            _logger = logger;
        }
        public async Task<ActionResult> Index()
        {
            var _class=await _classesService.GetAllClassesWithDetailsAsync();
            return View(_class);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {

            return View();
        }

        // POST: MaterialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClassDTO _class)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   await _classesService.CreateClassAsync(_class);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while adding the material.");
                }
            }

            return View(_class);

        }
        public async Task<IActionResult> Details(int id)
        {
            var _class = await _classesService.GetClassesWithStudentsAsync();
            if (_class == null)
            {
                return NotFound();
            }
           
            return View(_class);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _class = await _classesService.GetClassWithDetailsAsync(id);
            if (_class == null)
            {
                return NotFound();
            }

            return View(_class);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassDTO classDto)
        {

            if (id != classDto.ClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _classesService.EditClassAsync(classDto);
                return RedirectToAction(nameof(Index));
            }

            return View(classDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _class = await _classesService.GetClassWithDetailsAsync(id);
            if (_class == null)
            {
                return NotFound();
            }
            return View(_class);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _classesService.DeleteClassAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
