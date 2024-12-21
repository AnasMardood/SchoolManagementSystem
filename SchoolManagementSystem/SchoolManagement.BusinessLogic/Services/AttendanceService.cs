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
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;
        private readonly ILogger<AttendanceService> _logger;

        public AttendanceService(IAttendanceRepository repository, ILogger<AttendanceService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task CreateAttendanceAsync(AttendanceDTO Attendancedto)
        {

            try
            {
              var attendance=AttendanceMapper.Map(Attendancedto); 

                _repository.Create(attendance);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while Create attendances .");
                throw;
            }
        }

        public async Task DeleteAttendanceAsync(int  AttendanceId)
        {
            try
            {
                var attendance = await _repository.GetAttendancesWithDetailsAsync(AttendanceId);
                _repository.Delete(attendance);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while Delete attendances .");
                throw;
            }
        }

        public async Task EditAttendanceAsync(AttendanceDTO Attendancedto)
        {
            try
            {
                var attendance = await _repository.GetAttendancesWithDetailsAsync(Attendancedto.AttendanceID);
                attendance.StudentID = Attendancedto.StudentID;
                attendance.MaterialID = Attendancedto.MaterialID;
                attendance.Status = Attendancedto.Status;
                attendance.Date = Attendancedto.Date;
                
                _repository.Update(attendance);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while Update attendances  ID {Attendancedto.AttendanceID}.");
                throw;
            }
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

        public async Task<AttendanceDTO> GetAttendancesWithDetailsAsync(int attendaneDto)
        {
            try
            {
                var attendance = await _repository.GetAttendancesWithDetailsAsync(attendaneDto);
                return AttendanceMapper.Map(attendance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching attendances ID {attendaneDto}.");
                throw;
            }
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesWithDetailsAsync()
        {
            try
            {
                var attendances = await _repository.GetAttendancesWithDetailsAsync();
                return attendances.Select(AttendanceMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching attendances .");
                throw;
            }
        }
    }
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByMaterialIdAsync(int materialId);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId);
        Task<AttendanceDTO> GetAttendancesWithDetailsAsync(int studentId);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesWithDetailsAsync();
        Task CreateAttendanceAsync(AttendanceDTO Attendancedto);
        Task EditAttendanceAsync(AttendanceDTO Attendancedto);
        Task DeleteAttendanceAsync(int AttendanceId);

    }
}
