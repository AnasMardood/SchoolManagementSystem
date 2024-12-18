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
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdvisorService> _logger;

        public AdvisorService(IAdvisorRepository repository, ILogger<AdvisorService> logger,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _logger = logger;
        }

        public async Task CreateAdvisorAsync(AdvisorDTO advisorDto)
        {
            try
            {
                var _advisor = AdvisorMapper.Map(advisorDto);
                if (advisorDto.Materials != null && advisorDto.Materials.Any())
                {
                    _advisor.Materials = advisorDto.Materials.Select(m => new Materials
                    {
                        LessonsName = m.LessonsName,
                        CreditHours = m.CreditHours,
                        ClassID = m.ClassID
                    }).ToList();
                }

                _repository.Create(_advisor);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the advisor ");
                throw;
            }
        }

        public async Task DeleteAdvisorAsync(int advisorId)
        {
            _repository.Delete(_repository.GetById(advisorId));
            _repository.SaveChanges();
        }

        public async Task EditAdvisorAsync(AdvisorDTO advisorDto)
        {

            try
            {
  
               var advisor = await _repository.GetAdvisorWithMaterialsAsync(advisorDto.AdvisorID);
              //  var advisor = AdvisorMapper.Map(advisorDto);

                if (advisorDto.Materials == null) throw new Exception("Advisor not found");

                foreach(var _advisor in advisorDto.Materials)
                {
                    advisor.Materials.Add(new Materials { LessonsName=_advisor.LessonsName});
                }
               _repository.Update(advisor); 
              await _repository.SaveChangesAsync();

               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while update the advisor  ");
                throw;
            }
        }

        public async Task<AdvisorDTO> GetAdvisorByIdlsAsync(int advisorId)
        {
            try
            {
                var advisor= await _repository.GetAdvisorWithMaterialsAsync(advisorId);

                return AdvisorMapper.Map(advisor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the advisor with ID {advisorId}");
                throw;
            }
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

        public async Task<IEnumerable<AdvisorDTO>> GetAdvisorWithMaterialsAsync()
        {
            try
            {
                var advisor = await _repository.GetAdvisorWithMaterialsAsync();
                return advisor.Select(AdvisorMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching students");
                throw;
            }
        }

        public async Task<IEnumerable<AdvisorDTO>> GetAllAdvisorAsyn()
        {
            try
            {
                var advisors =await _repository.GetAsync();
                
                return advisors.Select(AdvisorMapper.Map).ToList();

            }catch(Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the advisors");
                throw;
            }
        }

    }
    public interface IAdvisorService
    {
        Task<AdvisorDTO> GetAdvisorWithMaterialsAsync(int advisorId);
        Task<IEnumerable<AdvisorDTO>> GetAllAdvisorAsyn();
        Task<AdvisorDTO> GetAdvisorByIdlsAsync(int advisorId);
        Task CreateAdvisorAsync(AdvisorDTO advisor);
        Task EditAdvisorAsync(AdvisorDTO advisor);
        Task DeleteAdvisorAsync(int advisorId);
        Task<IEnumerable<AdvisorDTO>> GetAdvisorWithMaterialsAsync();
    }
}
