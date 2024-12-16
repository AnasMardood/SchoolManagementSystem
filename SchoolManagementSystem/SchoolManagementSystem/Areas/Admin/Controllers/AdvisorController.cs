using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Mappers;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Models;


namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvisorController : Controller
    {
         private readonly IAdvisorService _advisorService;
        private readonly IMaterialsService _materialsService;
        private readonly ILogger<AdvisorController> _logger;

        public AdvisorController(IAdvisorService advisorService, IMaterialsService materialsService,ILogger<AdvisorController> logger)
        {
            _advisorService = advisorService;
            _materialsService=materialsService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var advisors =await _advisorService.GetAdvisorWithMaterialsAsync();
            return View(advisors);
        }

        // GET: AdvisorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var advisor=await _advisorService.GetAdvisorByIdlsAsync(id);
            if (advisor == null) NotFound();
            return View(advisor);
        }

        // GET: AdvisorController/Create
        public async Task<IActionResult> Create()
        {
              var materials=await _materialsService.GetMaterialsAsyn();
              ViewBag.Materials = new MultiSelectList(materials, "MaterialID", "LessonsName");

            return View();
        }

        // POST: AdvisorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvisorDTO advisorDto,List<int> selectedMaterials)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // قم بربط المواد المختارة مع الكائن MaterialsDTO
                    advisorDto.Materials = selectedMaterials.Select(id => new MaterialsDTO
                    {
                        MaterialID = id
                    }).ToList();

                    await _advisorService.CreateAdvisorAsync(advisorDto);
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while adding the advisor.");
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
            var materials = await _materialsService.GetMaterialsAsyn();
            ViewBag.Materials = new MultiSelectList(materials, "MaterialID", "LessonsName");
            return View(advisorDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var advisor =await _advisorService.GetAdvisorByIdlsAsync(id);
            return View(advisor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdvisorDTO advisorDto)
        {
            if (id != advisorDto.AdvisorID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                    await _advisorService.EditAdvisorAsync(advisorDto);
                    return RedirectToAction(nameof(Index));             
            }
            return View(advisorDto);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var advisor = await _advisorService.GetAdvisorByIdlsAsync(id);
            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _advisorService.DeleteAdvisorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
