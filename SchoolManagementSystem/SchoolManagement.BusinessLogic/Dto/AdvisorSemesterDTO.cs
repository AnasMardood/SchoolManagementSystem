using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class AdvisorSemesterDTO
    {
        public int AdvisorSemesterID { get; set; }
        public int AdvisorId { get; set; }
        public int SemesterId { get; set; }
        public string AssignmentYear { get; set; }
    }
}
