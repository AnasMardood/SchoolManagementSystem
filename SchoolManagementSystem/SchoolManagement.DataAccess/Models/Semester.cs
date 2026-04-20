using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    //العام الدراسي
    public class Semester
    {
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public ICollection<StudentSemester>? StudentSemesters { get; set; }
        public ICollection<AdvisorSemester>? AdvisorSemesters { get; set; } 

    }
}