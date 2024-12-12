using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class StudentMarkMapper
    {
        public static StudentMarkDTO Map(StudentMark studentMark)
        {
            return new StudentMarkDTO
            {
                GradeID = studentMark.GradeID,
                StudentID = studentMark.StudentID,
                MaterialID = studentMark.MaterialID,
                ExamType = studentMark.ExamType,
                Mark = studentMark.Mark
            };
        }

        public static List<StudentMarkDTO> Map(IEnumerable<StudentMark> studentMarks)
        {
            return studentMarks.Select(Map).ToList();
        }
    }

}
