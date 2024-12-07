    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SchoolManagement.DataAccess.Models
    {
        public class Materials
        {
            [Key]
            public int MaterialID { get; set; }
            public string LessonsName { get; set; }
            public int CreditHours { get; set; }
            public int AdvisorID { get; set; }
            public Advisor Advisor { get; set; }     
            public int ClassID { get; set; }
            public Classes Class { get; set; }
            
           public ICollection<StudentMaterial>? StudentMaterials { get; set; }
           public ICollection<Attendance>? Attendances { get; set; }
           public ICollection<StudentMark>? StudentMarks { get; set; }
        }
    }