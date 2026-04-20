using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var advisors = await _advisorService.GetAdvisorWithMaterialsAsync();
            return View(advisors);
        }

        // GET: AdvisorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
         var advisor = await _advisorService.GetAdvisorWithMaterialsAsync(id);
        if (advisor == null) return NotFound();

        return View(advisor);
        }

        // GET: AdvisorController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: AdvisorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvisorDTO advisorDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (advisorDto.PictureFile != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await advisorDto.PictureFile.CopyToAsync(memoryStream);
                            advisorDto.Picture = memoryStream.ToArray();
                        }
                    }
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
            return View(advisorDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var advisor =await _advisorService.GetAdvisorWithMaterialsAsync(id);
            if (advisor == null) return NotFound();

            return View(advisor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , AdvisorDTO advisorDto)
        {
            if (id != advisorDto.AdvisorID) return NotFound();
            if (ModelState.IsValid)
            {
                if (advisorDto.PictureFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await advisorDto.PictureFile.CopyToAsync(memoryStream);
                        advisorDto.Picture = memoryStream.ToArray();
                    }
                }
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
