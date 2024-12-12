using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class AnnouncementMapper
    {
        public static AnnouncementDTO Map(Announcement announcement)
        {
            return new AnnouncementDTO
            {
                AnnouncementID = announcement.AnnouncementID,
                Title = announcement.Title,
                Content = announcement.Content,
                CreatedDate = announcement.CreatedDate,
                AdvisorID = announcement.AdvisorID,
                TargetGroup = announcement.TargetGroup
            };
        }

        public static List<AnnouncementDTO> Map(IEnumerable<Announcement> announcements)
        {
            return announcements.Select(Map).ToList();
        }
    }

}
