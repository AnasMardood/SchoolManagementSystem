using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class AcademicCalendarMapper
    {
        public static AcademicCalendarDTO Map(AcademicCalendar calendar)
        {
            return new AcademicCalendarDTO
            {
                EventID = calendar.EventID,
                EventTitle = calendar.EventTitle,
                StartDate = calendar.StartDate,
                EndDate = calendar.EndDate,
                Description = calendar.Description,
                TargetGroup = calendar.TargetGroup,
                AdvisorID = calendar.AdvisorID
            };
        }

        public static List<AcademicCalendarDTO> Map(IEnumerable<AcademicCalendar> calendars)
        {
            return calendars.Select(Map).ToList();
        }
    }

}
