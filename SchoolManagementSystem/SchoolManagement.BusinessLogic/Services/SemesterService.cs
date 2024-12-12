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
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _repository;
        private readonly ILogger<SemesterService> _logger;

        public SemesterService(ISemesterRepository repository, ILogger<SemesterService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<SemesterDTO>> GetSemestersWithStudentsAsync()
        {
            try
            {
                var semesters = await _repository.GetSemestersWithStudentAsync();
                return semesters.Select(SemesterMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching semesters with students.");
                throw;
            }
        }
    }
    public interface ISemesterService
    {
        Task<IEnumerable<SemesterDTO>> GetSemestersWithStudentsAsync();
    }
}
