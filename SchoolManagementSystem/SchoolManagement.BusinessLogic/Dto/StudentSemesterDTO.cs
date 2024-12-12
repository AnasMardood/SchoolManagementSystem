using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class StudentSemesterDTO
    {
        public int StudentSemesterID { get; set; }
        public int StudentId { get; set; }
        public int SemesterId { get; set; }
        public string EnrollmentYear { get; set; }
    }
}
