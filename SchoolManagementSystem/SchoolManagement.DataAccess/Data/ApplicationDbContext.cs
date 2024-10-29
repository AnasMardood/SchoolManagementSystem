using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Models;

namespace SchoolManagement.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AcademicCalendar> AcademicCalendars { get; set; }
        public DbSet<AdvisorSemester> AdvisorSemesters { get; set; }
        public DbSet<StudentSemester> StudentSemesters { get; set; }
        public DbSet<StudentMark> StudentMarks { get; set; }


    }
}
