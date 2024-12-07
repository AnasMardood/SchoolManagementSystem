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
    }
}
