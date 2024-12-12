using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class AttendanceMapper
    {
        public static AttendanceDTO Map(Attendance attendance)
        {
            return new AttendanceDTO
            {
                AttendanceID = attendance.AttendanceID,
                Date = attendance.Date,
                Status = attendance.Status,
                StudentID = attendance.StudentID,
                AdvisorID = attendance.AdvisorID,
                MaterialID = attendance.MaterialID
            };
        }

        public static List<AttendanceDTO> Map(IEnumerable<Attendance> attendances)
        {
            return attendances.Select(Map).ToList();
        }
    }

}
