using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int? StudentID { get; set; }
        public Student? Student { get; set; }
        public int? AdvisorID {  get; set; }
        public Advisor? Advisor { get; set; }
        public int MaterialID { get; set; }
        public Materials Material { get; set; }
    }
}
