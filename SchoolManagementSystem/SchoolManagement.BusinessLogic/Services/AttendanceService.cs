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
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;
        private readonly ILogger<AttendanceService> _logger;

        public AttendanceService(IAttendanceRepository repository, ILogger<AttendanceService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByMaterialIdAsync(int materialId)
        {
            try
            {
                var attendances = await _repository.GetAttendancesByMaterialIdAsync(materialId);
                return attendances.Select(AttendanceMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching attendances for Material ID {materialId}.");
                throw;
            }
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId)
        {
            try
            {
                var attendances = await _repository.GetAttendancesByStudentIdAsync(studentId);
                return attendances.Select(AttendanceMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching attendances for Student ID {studentId}.");
                throw;
            }
        }
    }
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByMaterialIdAsync(int materialId);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId);
    }
}
