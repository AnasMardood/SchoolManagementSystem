using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class AttendanceDTO
    {
        public int AttendanceID { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int? StudentID { get; set; }
        public int? AdvisorID { get; set; }
        public int MaterialID { get; set; }
    }
}
