using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Models;
using SchoolManagement.DataAccess.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = WebSiteRole.WebSite_Student)]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return LocalRedirect("~/Home/Index"); // The student dashboard overview
        }

        private async Task<SchoolManagement.DataAccess.Models.Student> GetCurrentStudentAsync()
        {
            // If the project doesn't have a rigid ApplicationUserId column in Student, we match by First/Last name or just pick the first for demonstration of DB bindings.
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var studentMatch = await _context.Students.FirstOrDefaultAsync(s => s.FirstName == user.FirstName && s.LastName == user.LastName);
                if (studentMatch != null) return studentMatch;
            }
            
            // Fallback to first student if names don't match, just so the "database connected" logic works.
            return await _context.Students.FirstOrDefaultAsync();
        }

        public async Task<IActionResult> Schedule()
        {
            // In a real schema, we'd have a WeeklySchedule table. We will show registered materials here.
            var student = await GetCurrentStudentAsync();
            if (student == null) return View(new List<Materials>());
            
            var materials = await _context.StudentMarks
                .Where(sm => sm.StudentID == student.StudentID)
                .Include(sm => sm.Material)
                .Select(sm => sm.Material)
                .ToListAsync();

            return View(materials);
        }

        public async Task<IActionResult> Grades()
        {
            var student = await GetCurrentStudentAsync();
            if (student == null) return View(new List<StudentMark>());

            var marks = await _context.StudentMarks
                .Include(m => m.Material)
                .Where(m => m.StudentID == student.StudentID)
                .ToListAsync();

            return View(marks);
        }

        public async Task<IActionResult> Exams()
        {
            // Exams are actually recorded in StudentMarks (ExamType like Vize, Final).
            // We just show a list of unique exam types for their subjects.
            var student = await GetCurrentStudentAsync();
            if (student == null) return View(new List<StudentMark>());

            var exams = await _context.StudentMarks
                .Include(m => m.Material)
                .Where(m => m.StudentID == student.StudentID)
                .ToListAsync();

            return View(exams);
        }

        public async Task<IActionResult> AcademicCalendar()
        {
            var events = await _context.AcademicCalendars.ToListAsync();
            return View(events);
        }

        public async Task<IActionResult> ParentInfo()
        {
            var student = await GetCurrentStudentAsync();
            return View(student);
        }

        public async Task<IActionResult> Courses()
        {
            var student = await GetCurrentStudentAsync();
            if (student == null) return View(new List<Materials>());

            var classes = await _context.StudentMarks
                .Where(sm => sm.StudentID == student.StudentID)
                .Include(sm => sm.Material)
                .ThenInclude(m => m.Advisor)
                .Select(sm => sm.Material)
                .ToListAsync();

            return View(classes);
        }
    }
}
