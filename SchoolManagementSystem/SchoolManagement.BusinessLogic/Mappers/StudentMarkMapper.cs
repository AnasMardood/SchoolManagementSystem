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
                Mark = studentMark.Mark,
                StudentDTO = new StudentDTO()
                {
                    FirstName = studentMark.Student.FirstName,
                    LastName = studentMark.Student.LastName
                },
                MaterialsDTO = new MaterialsDTO() { LessonsName = studentMark.Material.LessonsName }

            };
        }

        public static List<StudentMarkDTO> Map(IEnumerable<StudentMark> studentMarks)
        {
            return studentMarks.Select(Map).ToList();
        }    
        public static StudentMark Map(StudentMarkDTO studentMark)
        {
            return new StudentMark
            {
                GradeID = studentMark.GradeID,
                StudentID = studentMark.StudentID,
                MaterialID = studentMark.MaterialID,
                ExamType = studentMark.ExamType,
                Mark = studentMark.Mark,
                Student = studentMark.StudentDTO != null ? new Student
                {
                    StudentID = studentMark.StudentDTO.StudentID,
                    FirstName = studentMark.StudentDTO.FirstName,
                    LastName = studentMark.StudentDTO.LastName
                } : null,

                Material = studentMark.MaterialsDTO != null ? new Materials
                {
                    MaterialID = studentMark.MaterialsDTO.MaterialID,
                    LessonsName = studentMark.MaterialsDTO.LessonsName
                } : null,

            };
        }

        public static List<StudentMark> Map(IEnumerable<StudentMarkDTO> studentMarks)
        {
            return studentMarks.Select(Map).ToList();
        }
    }

}
