using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;
using SchoolManagement.DataAccess.Models;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialsController : Controller
    {
        private readonly IMaterialsService _materialsService;
        private readonly IClassesService _classesService;
        private readonly IAdvisorService _advisorService;
        private readonly ILogger<MaterialsController> _logger;
        public MaterialsController(IMaterialsService materialsService, ILogger<MaterialsController> logger,IClassesService classesService, IAdvisorService advisorService)
        {
            _materialsService = materialsService;
            _classesService = classesService;
            _logger = logger;
            _advisorService = advisorService;
        }
        // GET: MaterialsController
        public async Task<ActionResult> Index()
        {
            var material =await _materialsService.GetMaterialsAsyn();
            return View(material);
        }

        // GET: MaterialsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MaterialsController/Create
        public async Task<ActionResult> Create()
        {
            var classes = await _classesService.GetAllClasses();
            var advisors = await _advisorService.GetAllAdvisorAsyn();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName");
            ViewBag.Advisors = new SelectList(advisors, "AdvisorID", "FirstName");

            return View();
        }

        // POST: MaterialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(MaterialsDTO materialsDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  await _materialsService.CreateMaterialAsyn(materialsDTO);

                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while adding the material.");
                }
            }
            var classes = await _classesService.GetAllClasses();
            var advisors = await _advisorService.GetAllAdvisorAsyn();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName");
            ViewBag.Advisors = new SelectList(advisors, "AdvisorID", "FirstName");
            return View(materialsDTO);

        }

        // GET: MaterialsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var material =await _materialsService.GetMaterialsWithDetails(id);
            var classes = await _classesService.GetAllClasses();
            var advisors = await _advisorService.GetAllAdvisorAsyn();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName");
            ViewBag.Advisors = new SelectList(advisors, "AdvisorID", "FirstName");
            return View(material);
        }

        // POST: MaterialsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Edit(int id, MaterialsDTO materialsDTO)
        {
            if (id != materialsDTO.MaterialID) return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                   await _materialsService.EditMaterialAsyn(materialsDTO);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the material.");

            }
            var classes = await _classesService.GetAllClasses();
            var advisors = await _advisorService.GetAllAdvisorAsyn();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName");
            ViewBag.Advisors = new SelectList(advisors, "AdvisorID", "FirstName");
            return View(materialsDTO);
        }

        // GET: MaterialsController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var material = await _materialsService.GetMaterialsWithDetails(id);
            if (material == null) return NotFound();
            var classes = await _classesService.GetAllClasses();
            var advisors = await _advisorService.GetAllAdvisorAsyn();
            ViewBag.Classes = new SelectList(classes, "ClassID", "ClassName");
            ViewBag.Advisors = new SelectList(advisors, "AdvisorID", "FirstName");
            return View(material);
        }

        // POST: MaterialsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _materialsService.DeleteMaterialAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while Delete the material.");
                throw;
            }
        }
    }
}
