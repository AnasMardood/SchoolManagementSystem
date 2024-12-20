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
                MaterialID = attendance.MaterialID,
                StudentDTO = new StudentDTO() { FirstName =attendance.Student.FirstName,
                                                 LastName = attendance.Student.LastName},
                MaterialsDTO=new MaterialsDTO() { LessonsName = attendance.Material.LessonsName}
            };
        }

        public static List<AttendanceDTO> Map(IEnumerable<Attendance> attendances)
        {
            return attendances.Select(Map).ToList();
        }       
        public static Attendance Map(AttendanceDTO attendance)
        {
            return new Attendance
            {
                AttendanceID = attendance.AttendanceID,
                Date = attendance.Date,
                Status = attendance.Status,
                StudentID = attendance.StudentID,
                MaterialID = attendance.MaterialID,
                Student =new Student() { FirstName =attendance.StudentDTO.FirstName,
                                          LastName =attendance.StudentDTO.LastName},
                Material=new Materials() { LessonsName = attendance.MaterialsDTO.LessonsName}
                
            };
        }

        public static List<Attendance> Map(IEnumerable<AttendanceDTO> attendances)
        {
            return attendances.Select(Map).ToList();
        }
    }

}
