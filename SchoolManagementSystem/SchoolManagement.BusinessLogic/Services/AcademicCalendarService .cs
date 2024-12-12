using Microsoft.Extensions.Logging;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Mappers;
using SchoolManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Services
{
  
    public class AcademicCalendarService : IAcademicCalendarService
    {
        private readonly IAcademicCalendarRepository _repository;
        private readonly ILogger<AcademicCalendarService> _logger;

        public AcademicCalendarService(IAcademicCalendarRepository repository, ILogger<AcademicCalendarService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<AcademicCalendarDTO>> GetEventsForMonthAsync(DateTime month)
        {
            try
            {
                var events = await _repository.GetEventsForMonthAsync(month);
                return events.Select(AcademicCalendarMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching events for the month.");
                throw;
            }
        }

        public async Task<AcademicCalendarDTO> GetEventDetailsAsync(int eventId)
        {
            try
            {
                var eventDetails = await _repository.GetEventDetailsAsync(eventId);
                return eventDetails != null ? AcademicCalendarMapper.Map(eventDetails) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching event details.");
                throw;
            }
        }
    }
    public interface IAcademicCalendarService
    {
        Task<IEnumerable<AcademicCalendarDTO>> GetEventsForMonthAsync(DateTime month);
        Task<AcademicCalendarDTO> GetEventDetailsAsync(int eventId);
    }
}
