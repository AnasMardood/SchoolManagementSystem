using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class StudentMarkDTO
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int MaterialID { get; set; }
        public string ExamType { get; set; }
        public decimal Mark { get; set; }
    }
}
