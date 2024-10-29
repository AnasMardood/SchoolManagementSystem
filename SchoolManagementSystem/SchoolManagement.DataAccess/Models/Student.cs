using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollementDate { get; set; }
        public string ParentPhone { get; set; }
        public string StudentPhone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public byte ProfilePicture { get; set; }
        public string Nationality { get; set; }
        public int ClassID {  get; set; }
        public Classes Class {  get; set; }
        public ICollection<StudentSemester>? StudentSemesters { get; set; } 
        public ICollection<Materials>? Materials { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<StudentMark>? StudentMark { get; set; }
    }
}