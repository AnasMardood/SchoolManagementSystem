﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class Classes
    {
        [Key]
        public int  ClassID {  get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Materials> Materials { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}