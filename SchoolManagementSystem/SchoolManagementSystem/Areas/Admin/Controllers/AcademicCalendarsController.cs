using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Models;
using SchoolManagement.DataAccess.Utilities;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
    public class AcademicCalendarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademicCalendarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AcademicCalendars.Include(a => a.Advisor);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicCalendar = await _context.AcademicCalendars
                .Include(a => a.Advisor)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (academicCalendar == null)
            {
                return NotFound();
            }

            return View(academicCalendar);
        }

        public IActionResult Create()
        {
            ViewData["AdvisorID"] = new SelectList(_context.Advisors, "AdvisorID", "FirstName");
            return View();
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,EventTitle,StartDate,EndDate,Description,TargetGroup,AdvisorID")] AcademicCalendar academicCalendar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicCalendar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvisorID"] = new SelectList(_context.Advisors, "AdvisorID", "Address", academicCalendar.AdvisorID);
            return View(academicCalendar);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicCalendar = await _context.AcademicCalendars.FindAsync(id);
            if (academicCalendar == null)
            {
                return NotFound();
            }
            ViewData["AdvisorID"] = new SelectList(_context.Advisors, "AdvisorID", "Address", academicCalendar.AdvisorID);
            return View(academicCalendar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventTitle,StartDate,EndDate,Description,TargetGroup,AdvisorID")] AcademicCalendar academicCalendar)
        {
            if (id != academicCalendar.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicCalendar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicCalendarExists(academicCalendar.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvisorID"] = new SelectList(_context.Advisors, "AdvisorID", "Address", academicCalendar.AdvisorID);
            return View(academicCalendar);
        }

        // GET: Admin/AcademicCalendars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicCalendar = await _context.AcademicCalendars
                .Include(a => a.Advisor)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (academicCalendar == null)
            {
                return NotFound();
            }

            return View(academicCalendar);
        }

        // POST: Admin/AcademicCalendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicCalendar = await _context.AcademicCalendars.FindAsync(id);
            if (academicCalendar != null)
            {
                _context.AcademicCalendars.Remove(academicCalendar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicCalendarExists(int id)
        {
            return _context.AcademicCalendars.Any(e => e.EventID == id);
        }
    }
}
