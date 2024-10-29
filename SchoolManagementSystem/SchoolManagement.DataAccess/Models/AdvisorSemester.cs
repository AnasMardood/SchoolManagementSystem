using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class AdvisorSemester
    {
        public int AdvisorSemesterID { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public string AssignmentYear{ get; set; }
    }
}
