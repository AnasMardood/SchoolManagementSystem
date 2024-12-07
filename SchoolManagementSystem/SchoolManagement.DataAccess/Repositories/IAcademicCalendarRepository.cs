using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public interface IAcademicCalendarRepository : IBaseRepository<AcademicCalendar>
    {
        Task<IEnumerable<AcademicCalendar>> GetEventsForMonthAsync(DateTime month);
        Task<AcademicCalendar> GetEventDetailsAsync(int eventId);
    }
}
