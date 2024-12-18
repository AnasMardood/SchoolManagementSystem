using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class MaterialsDTO
    {
        public int MaterialID { get; set; }
        public string LessonsName { get; set; }
        public int CreditHours { get; set; }
        public int ClassID { get; set; }
    }
}
