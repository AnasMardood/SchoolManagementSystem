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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repository, ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<StudentDTO> GetStudentWithDetailsAsync(int studentId)
        {
            try
            {
                var student = await _repository.GetStudentWithDetailsAsync(studentId);
                return StudentMapper.Map(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching details for Student ID {studentId}.");
                throw;
            }
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsByClassAsync(int classId)
        {
            try
            {
                var students = await _repository.GetStudentByClassAsync(classId);
                return students.Select(StudentMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching students for Class ID {classId}.");
                throw;
            }
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudent()
        {
            try
            {
                var students = await _repository.GetAllStudent();
                return students.Select(StudentMapper.Map).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching students");
                throw;
            }
        }

        public async Task CreateStudentAsync(StudentDTO student)
        {
            try
            {
                var _student = StudentMapper.Map(student);
               _repository.Create(_student);
                
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while create student");
                throw;
            }
        }
    }
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudent();
        Task CreateStudentAsync(StudentDTO student);
        Task<StudentDTO> GetStudentWithDetailsAsync(int studentId);
        Task<IEnumerable<StudentDTO>> GetStudentsByClassAsync(int classId);
    }
}
