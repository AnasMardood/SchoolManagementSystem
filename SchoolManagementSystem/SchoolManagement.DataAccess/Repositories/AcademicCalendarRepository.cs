using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolManagement.DataAccess.Repositories.AcademicCalendarRepository;

namespace SchoolManagement.DataAccess.Repositories
{
    public class AcademicCalendarRepository : BaseRepository<AcademicCalendar> ,IAcademicCalendarRepository
    {
        public AcademicCalendarRepository(ApplicationDbContext context, ILogger<AcademicCalendarRepository> logger)
          : base(context, logger)
        {
        }

        // Bring events for a specific month
        public async Task<IEnumerable<AcademicCalendar>> GetEventsForMonthAsync(DateTime month)
        {
            return await _dbSet
                .Where(e => e.StartDate.Month == month.Month && e.StartDate.Year == month.Year)
                .ToListAsync();
        }

        // Retrieve details of a specific event
        public async Task<AcademicCalendar> GetEventDetailsAsync(int eventId)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.EventID == eventId);
        }
        public interface IAcademicCalendarRepository : IBaseRepository<AcademicCalendar>
        {
            Task<IEnumerable<AcademicCalendar>> GetEventsForMonthAsync(DateTime month);
            Task<AcademicCalendar> GetEventDetailsAsync(int eventId);
        }
    }
}

