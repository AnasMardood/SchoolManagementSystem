using Microsoft.Extensions.Logging;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Mappers;
using SchoolManagement.DataAccess.Models;
using SchoolManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Services
{
    public class MaterialsService : IMaterialsService
    {
        private readonly IMaterialsRepository _repository;
        private readonly ILogger<MaterialsService> _logger;

        public MaterialsService(IMaterialsRepository repository, ILogger<MaterialsService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<MaterialsDTO>> GetMaterialsAsyn()
        {
            try
            {
                var materials = await _repository.GetAsync();
                return materials.Select(MaterialsMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching materials .");
                throw;
            }
        }

        public async Task<IEnumerable<MaterialsDTO>> GetMaterialsByClassAsync(int classId)
        {
            try
            {
                var materials = await _repository.GetMaterialsBySemesterAsync(classId);
                return materials.Select(MaterialsMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching materials for Class ID {classId}.");
                throw;
            }
        }
        public async Task<MaterialsDTO> EditMaterialAsyn(MaterialsDTO materialDto)
        {
            try
            {
                var material = await _repository.GetMaterialsWithDetailsAsync(materialDto.MaterialID);
                material.LessonsName = materialDto.LessonsName;
                material.CreditHours = materialDto.CreditHours;
                material.ClassID = materialDto.ClassID;
                material.AdvisorID = materialDto.AdvisorID;
                
                _repository.Update(material);
                await _repository.SaveChangesAsync();
                return MaterialsMapper.Map(material);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while update material {materialDto.MaterialID}.");
                throw;
            }
        }
        public async Task CreateMaterialAsyn(MaterialsDTO materialDto)
        {
            try
            {
                var material = MaterialsMapper.Map(materialDto);
                _repository.Create(material);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while Create material {materialDto.MaterialID}.");
                throw;
            }
        }

        public async Task<MaterialsDTO> GetMaterialsWithDetails(int materialId)
        {
            try
            {
                var materials = await _repository.GetMaterialsWithDetailsAsync(materialId);
                return MaterialsMapper.Map(materials);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching materials for material ID {materialId}.");
                throw;
            }

        }

        public async Task DeleteMaterialAsync(int materialId)
        {
            try
            {
                var material = await _repository.GetByIdAsync(materialId);
                _repository.Delete(material);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while delete material for material ID {materialId}.");
                throw;
            }


        }
    }
    public interface IMaterialsService
    {
        Task<IEnumerable<MaterialsDTO>> GetMaterialsByClassAsync(int classId);
        Task<IEnumerable<MaterialsDTO>> GetMaterialsAsyn();
        Task CreateMaterialAsyn(MaterialsDTO materialDto);
        Task<MaterialsDTO> EditMaterialAsyn(MaterialsDTO materialDto);
        Task<MaterialsDTO> GetMaterialsWithDetails(int materialId);
        Task DeleteMaterialAsync(int materialId);
    }
}
