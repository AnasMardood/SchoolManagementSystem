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
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository _repository;
        private readonly ILogger<AdvisorService> _logger;

        public AdvisorService(IAdvisorRepository repository, ILogger<AdvisorService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<AdvisorDTO> GetAdvisorWithMaterialsAsync(int advisorId)
        {
            try
            {
                var advisor = await _repository.GetAdvisorWithMaterialsAsync(advisorId);
                return advisor != null ? AdvisorMapper.Map(advisor) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the advisor with ID {advisorId}.");
                throw;
            }
        }
    }
    public interface IAdvisorService
    {
        Task<AdvisorDTO> GetAdvisorWithMaterialsAsync(int advisorId);
    }
}
