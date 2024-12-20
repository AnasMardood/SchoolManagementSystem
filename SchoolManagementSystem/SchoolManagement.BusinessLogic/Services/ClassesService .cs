using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task CreateClassAsync(ClassDTO _class)
        {
            try
            {
                var clasess = ClassMapper.Map(_class);
                      _repository.Create(clasess);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while Create class.");
                throw;
            }
        }

        public async Task DeleteClassAsync(int _classId)
        {
            try
            {
               var _class= await _repository.GetClassWithDetailsAsync(_classId);
                _repository.Delete(_class);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching classes.");
                throw;
            }
        }

        public async Task<ClassDTO> EditClassAsync(ClassDTO classDto)
        {
            try
            {
                var _class = await _repository.GetClassWithDetailsAsync(classDto.ClassID);
                if(_class == null ) { throw new UnauthorizedAccessException("Error "); }
                _class.ClassName = classDto.ClassName;
                _repository.Update(_class);
                await _repository.SaveChangesAsync();
                return ClassMapper.Map(_class);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching class.");
                throw;
            }
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

        public async Task<IEnumerable<ClassDTO>> GetAllClassesWithDetailsAsync()
        {
            try
            {
                var classes = await _repository.GetAllClassesWithDetailsAsync();
                return classes.Select(ClassMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching classes with students.");
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

        public async Task<ClassDTO> GetClassWithDetailsAsync(int _classId)
        {
            try
            {
                var _class = await _repository.GetClassWithDetailsAsync(_classId);
                return ClassMapper.Map(_class);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching classes with ID : {_classId}" );
                throw;
            }
        }
    }
    public interface IClassesService
    {
        Task<IEnumerable<ClassDTO>> GetClassesWithStudentsAsync();
        Task<IEnumerable<ClassDTO>> GetAllClasses();
        Task<IEnumerable<ClassDTO>> GetAllClassesWithDetailsAsync();
        Task CreateClassAsync(ClassDTO _class);
        Task<ClassDTO> GetClassWithDetailsAsync(int _classId);
        Task<ClassDTO> EditClassAsync(ClassDTO _class);
        Task DeleteClassAsync(int _classId);

    }
}
