using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class StudentMapper
    {
        public static StudentDTO Map(Student student)
        {
            return new StudentDTO
            {
                StudentID = student.StudentID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MotherName = student.MotherName,
                FatherName = student.FatherName,
                BirthDate = student.BirthDate,
                EnrollementDate = student.EnrollementDate,
                ParentPhone = student.ParentPhone,
                StudentPhone = student.StudentPhone,
                Gender = student.Gender,
                Address = student.Address,
                Status = student.Status,
                ProfilePicture = student.ProfilePicture,
                Nationality = student.Nationality,
                ClassID = student.ClassID,
                
            };
        }

        public static List<StudentDTO> Map(IEnumerable<Student> students)
        {
            return students.Select(Map).ToList();
        }
        public static Student Map(StudentDTO student)
        {
            return new Student
            {
                StudentID = student.StudentID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MotherName = student.MotherName,
                FatherName = student.FatherName,
                BirthDate = student.BirthDate,
                EnrollementDate = student.EnrollementDate,
                ParentPhone = student.ParentPhone,
                StudentPhone = student.StudentPhone,
                Gender = student.Gender,
                Address = student.Address,
                Status = student.Status,
                ProfilePicture = student.ProfilePicture,
                Nationality = student.Nationality,
                ClassID = student.ClassID

            };
        }

        public static List<Student> Map(IEnumerable<StudentDTO> students)
        {
            return students.Select(Map).ToList();
        }
    }

}
