using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class StudentSemester
    {
        public int StudentSemesterID { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public string EnrollmentYear { get; set; }
    }
}
