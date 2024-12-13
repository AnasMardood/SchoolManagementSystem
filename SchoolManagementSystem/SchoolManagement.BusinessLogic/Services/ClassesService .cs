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
    public class ClassesService : IClassesService
    {
        private readonly IClassesRepository _repository;
        private readonly ILogger<ClassesService> _logger;

        public ClassesService(IClassesRepository repository, ILogger<ClassesService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<ClassDTO>> GetAllClasses()
        {
            try
            {
                var classes = await _repository.GetAllClasses();
                return classes.Select(ClassMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching classes.");
                throw;
            }
        }

        public async Task<IEnumerable<ClassDTO>> GetClassesWithStudentsAsync()
        {
            try
            {
                var classes = await _repository.GetClassesWithStudentAsync();
                return classes.Select(ClassMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching classes with students.");
                throw;
            }
        }
    }
    public interface IClassesService
    {
        Task<IEnumerable<ClassDTO>> GetClassesWithStudentsAsync();
        Task<IEnumerable<ClassDTO>> GetAllClasses();

    }
}
