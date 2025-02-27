﻿using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public interface IAttendanceRepository : IBaseRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetAttendancesByMaterialIdAsync(int materialId);
        Task<IEnumerable<Attendance>> GetAttendancesByStudentIdAsync(int studentId);
        Task<IEnumerable<Attendance>> GetAttendancesWithDetailsAsync();
        Task<Attendance> GetAttendancesWithDetailsAsync(int attendanceId);


    }
}
