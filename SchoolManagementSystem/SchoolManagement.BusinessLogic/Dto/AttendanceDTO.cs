using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class AttendanceDTO
    {
        public int AttendanceID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int? StudentID { get; set; }
        public int MaterialID { get; set; }
        public StudentDTO StudentDTO { get; set; }
        public MaterialsDTO MaterialsDTO { get; set; }
    }
}
