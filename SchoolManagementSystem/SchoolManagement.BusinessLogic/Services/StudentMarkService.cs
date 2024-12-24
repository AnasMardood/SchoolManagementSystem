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
    public class StudentMarkService : IStudentMarkService
    {
        private readonly IStudentMarkRepository _repository;
        private readonly ILogger<StudentMarkService> _logger;

        public StudentMarkService(IStudentMarkRepository repository , ILogger<StudentMarkService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<StudentMarkDTO>> GetAllStudentMarksAsync()
        {
            var studentMarks = await _repository.GetAllStudentMarksWithDetailsAsync();
            return StudentMarkMapper.Map(studentMarks);
        }

        public async Task<StudentMarkDTO> GetStudentMarkByIdAsync(int gradeId)
        {
            var studentMark = await _repository.GetStudentMarkByIdWithDetailsAsync(gradeId);
            return studentMark != null ? StudentMarkMapper.Map(studentMark) : null;
        }

        public async Task CreatetudentMarkAsync(StudentMarkDTO studentMarkDto)
        {
            try
            {
                var studentMark = StudentMarkMapper.Map(studentMarkDto);
                _repository.Create(studentMark);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while create Student .");
                throw;
            }

        }

        public async Task UpdateStudentMarkAsync(StudentMarkDTO studentMarkDto)
        {
            var studentMark = StudentMarkMapper.Map(studentMarkDto);
            _repository.Update(studentMark);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteStudentMarkAsync(int gradeId)
        {
            var studentMark = await _repository.GetByIdAsync(gradeId);
            if (studentMark != null)
            {
                _repository.Delete(studentMark);
                await _repository.SaveChangesAsync();
            }
        }
    }

    public interface IStudentMarkService
    {
        Task<List<StudentMarkDTO>> GetAllStudentMarksAsync();
        Task<StudentMarkDTO> GetStudentMarkByIdAsync(int gradeId);
        Task CreatetudentMarkAsync(StudentMarkDTO studentMarkDto);
        Task UpdateStudentMarkAsync(StudentMarkDTO studentMarkDto);
        Task DeleteStudentMarkAsync(int gradeId);
    }
}
