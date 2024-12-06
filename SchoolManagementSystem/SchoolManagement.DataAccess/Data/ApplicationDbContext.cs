using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Models;

namespace SchoolManagement.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentMaterial>()
                .HasKey(sm => new { sm.StudentID, sm.MaterialID });
            modelBuilder.Entity<StudentMaterial>()
                .HasOne(sm => sm.Student)
                .WithMany(s => s.StudentMaterials)
                .HasForeignKey(sm => sm.StudentID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentMaterial>()
                .HasOne(sm => sm.Material)
                .WithMany(m => m.StudentMaterials)
                .HasForeignKey(sm => sm.MaterialID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentSemester>()
                .HasKey(ss=>new {ss.StudentId,ss.SemesterId});
            modelBuilder.Entity<StudentSemester>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSemesters)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentSemester>()
                .HasOne(ss => ss.Semester)
                .WithMany(s => s.StudentSemesters)
                .HasForeignKey(ss => ss.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdvisorSemester>()
                .HasKey(As => new { As.AdvisorId, As.SemesterId });
            modelBuilder.Entity<AdvisorSemester>()
                .HasOne(As => As.Advisor)
                .WithMany(a => a.AdvisorSemesters)
                .HasForeignKey(As => As.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AdvisorSemester>()
                .HasOne(As => As.Semester)
                .WithMany(s => s.AdvisorSemesters)
                .HasForeignKey(As => As.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AcademicCalendar>()
                .HasOne(ac => ac.Advisor)
                .WithMany(a => a.AcademicCalendars)
                .HasForeignKey(ac => ac.AdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Announcement>()
                .HasOne(a => a.Advisor)
                .WithMany(ad => ad.Announcements)
                .HasForeignKey(a => a.AdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Advisor)
                .WithMany(ad => ad.Attendances)
                .HasForeignKey(a => a.AdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Advisor)
                .WithMany(a => a.Messages)
                .HasForeignKey(m => m.AdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentMark>()
                .HasOne(sm => sm.Material)
                .WithMany(m => m.StudentMarks)
                .HasForeignKey(sm => sm.MaterialID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentMark>()
                .HasOne(sm => sm.Student)
                .WithMany(s => s.StudentMark)
                .HasForeignKey(sm => sm.StudentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Materials>()
                .HasOne(m => m.Advisor)
                .WithMany(a => a.Materials)
                .HasForeignKey(m => m.AdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
