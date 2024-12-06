using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class StudentMaterial
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int MaterialID { get; set; }
        public Materials Material { get; set; }
    }
}
