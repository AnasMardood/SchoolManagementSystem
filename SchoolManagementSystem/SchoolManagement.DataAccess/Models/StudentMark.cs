using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class StudentMark
    {
        [Key]
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int MaterialID { get; set; }
        public Materials Material { get; set; }
        public string ExamType { get; set; }
        public decimal Mark { get; set; }
    }
}
