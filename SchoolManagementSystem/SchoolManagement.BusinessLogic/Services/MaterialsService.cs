using Microsoft.Extensions.Logging;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Mappers;
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
    }
    public interface IMaterialsService
    {
        Task<IEnumerable<MaterialsDTO>> GetMaterialsByClassAsync(int classId);
    }
}
