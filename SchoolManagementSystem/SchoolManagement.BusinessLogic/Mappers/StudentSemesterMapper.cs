using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class StudentSemesterMapper
    {
        public static StudentSemesterDTO Map(StudentSemester studentSemester)
        {
            return new StudentSemesterDTO
            {
                StudentSemesterID = studentSemester.StudentSemesterID,
                StudentId = studentSemester.StudentId,
                SemesterId = studentSemester.SemesterId,
                EnrollmentYear = studentSemester.EnrollmentYear
            };
        }

        public static List<StudentSemesterDTO> Map(IEnumerable<StudentSemester> studentSemesters)
        {
            return studentSemesters.Select(Map).ToList();
        }
    }

}
