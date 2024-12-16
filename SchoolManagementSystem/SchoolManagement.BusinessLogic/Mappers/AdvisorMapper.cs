using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class AdvisorMapper
    {
        public static AdvisorDTO Map(Advisor advisor)
        {
            return new AdvisorDTO
            {
                AdvisorID = advisor.AdvisorID,
                FirstName = advisor.FirstName,
                LastName = advisor.LastName,
                Nationality = advisor.Nationality,
                Email = advisor.Email,
                Phone = advisor.Phone,
                Address = advisor.Address,
                EnrollmentDate = advisor.EnrollmentDate,
                ProfilePicture = advisor.ProfilePicture,
                Role = advisor.Role,
                Materials = advisor.Materials?.Select(m => new MaterialsDTO
                {  MaterialID = m.MaterialID}).ToList()
            };
        }

        public static List<AdvisorDTO> Map(IEnumerable<Advisor> advisors)
        {
            return advisors.Select(Map).ToList();
        }      
        public static Advisor Map(AdvisorDTO advisor)
        {
            return new Advisor
            {
                AdvisorID = advisor.AdvisorID,
                FirstName = advisor.FirstName,
                LastName = advisor.LastName,
                Nationality = advisor.Nationality,
                Email = advisor.Email,
                Phone = advisor.Phone,
                Address = advisor.Address,
                EnrollmentDate = advisor.EnrollmentDate,
                ProfilePicture = advisor.ProfilePicture,
                Role = advisor.Role,
                Materials = advisor.Materials ?.Select(m => new Materials { MaterialID = m.MaterialID ,
                                                                            AdvisorID = m.AdvisorID,
                                                                            
                })
            .ToList()
            };
        }

        public static List<Advisor> Map(IEnumerable<AdvisorDTO> advisors)
        {
            return advisors.Select(Map).ToList();
        }
    }

}
