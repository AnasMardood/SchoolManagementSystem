using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class AdvisorDTO
    {
        public int AdvisorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        public byte[]? Picture { get; set; }
        public IFormFile? PictureFile { get; set; }
        public string Role { get; set; }
        public List<MaterialsDTO> Materials { get; set; }
    }
}
