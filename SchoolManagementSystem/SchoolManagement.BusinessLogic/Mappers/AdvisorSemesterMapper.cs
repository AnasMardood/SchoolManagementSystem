using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class AdvisorSemesterMapper
    {
        public static AdvisorSemesterDTO Map(AdvisorSemester advisorSemester)
        {
            return new AdvisorSemesterDTO
            {
                AdvisorSemesterID = advisorSemester.AdvisorSemesterID,
                AdvisorId = advisorSemester.AdvisorId,
                SemesterId = advisorSemester.SemesterId,
                AssignmentYear = advisorSemester.AssignmentYear
            };
        }

        public static List<AdvisorSemesterDTO> Map(IEnumerable<AdvisorSemester> advisorSemesters)
        {
            return advisorSemesters.Select(Map).ToList();
        }
    }

}
