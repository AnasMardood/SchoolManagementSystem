using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class Classes
    {
        public int  ClassID {  get; set; }
        public string ClassName { get; set; }
        public ICollection<Materials> Materials { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}