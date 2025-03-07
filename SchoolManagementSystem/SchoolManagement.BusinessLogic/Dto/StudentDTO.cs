﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnrollementDate { get; set; } 
        public string ParentPhone { get; set; }
        public string StudentPhone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Status { get; set; } 
        public byte[]? ProfilePicture { get; set; }
        public IFormFile? PictureFile { get; set; }
        public string Nationality { get; set; }
        public int ClassID { get; set; }
        public ClassDTO? ClassDTO { get; set; }

       
    }
}
