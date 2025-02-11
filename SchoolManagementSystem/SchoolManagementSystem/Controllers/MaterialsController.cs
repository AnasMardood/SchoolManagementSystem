using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialsService _materialsService;

        public MaterialsController(IMaterialsService materialsService)
        {
            _materialsService = materialsService;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<IActionResult> GetAllMaterials()
        {
            try
            {
                var materials = await _materialsService.GetMaterialsAsyn();
                return Ok(materials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Materials/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialById(int id)
        {
            try
            {
                var material = await _materialsService.GetMaterialsWithDetails(id);
                if (material == null)
                    return NotFound($"Material with ID {id} not found.");
                return Ok(material);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Materials/Class/{classId}
        [HttpGet("Class/{classId}")]
        public async Task<IActionResult> GetMaterialsByClass(int classId)
        {
            try
            {
                var materials = await _materialsService.GetMaterialsByClassAsync(classId);
                return Ok(materials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
