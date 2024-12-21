using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public class AttendanceRepository : BaseRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(ApplicationDbContext context, ILogger<AttendanceRepository> logger) : base(context, logger) { }


        public async Task<IEnumerable<Attendance>> GetAttendancesByMaterialIdAsync(int materialId)
        {
            return await _context.Attendances
                                 .Where(a => a.MaterialID == materialId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByStudentIdAsync(int studentId)
        {
            return await _context.Attendances
                                 .Where(a => a.StudentID == studentId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesWithDetailsAsync()
        {
            return await _dbSet.Include(s => s.Student)
                                .Include(a => a.Advisor)
                                .Include(m => m.Material)
                                .ToListAsync();

        }     
        public async Task<Attendance> GetAttendancesWithDetailsAsync(int attendanceId)
        {
            return await _dbSet.Include(s => s.Student)
                                .Include(a => a.Advisor)
                                .Include(m => m.Material)
                                .FirstOrDefaultAsync(A => A.AttendanceID == attendanceId);

        }
    }
}
