using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class Advisor
    {
        public int AdvisorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string ProfilePicture { get; set; }
        public string Role { get; set; }
        public ICollection<Materials>? Materials { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Announcement>? Announcements { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public ICollection<AdvisorSemester>? AdvisorSemesters { get; set; }
        public ICollection<AcademicCalendar>? AcademicCalendars { get; set; }

    }
}
