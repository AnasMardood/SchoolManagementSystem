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
                Role = advisor.Role
            };
        }

        public static List<AdvisorDTO> Map(IEnumerable<Advisor> advisors)
        {
            return advisors.Select(Map).ToList();
        }
    }

}
