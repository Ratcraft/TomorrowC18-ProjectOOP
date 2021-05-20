using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace TomorrowC18ProjectOOP.Controllers
{
    public class AcademicCalendarController : Controller
    {
        private readonly Context _context;

        public AcademicCalendarController(Context context)
        {
            _context = context;
        }

        // Get : AcademicCalendar
        public IActionResult Index()
        {
            return View();
        }

        // GET: AcademicCalendar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicCalendar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Event, StartDate, EndDate")] AcademicCalendar academicCalendar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicCalendar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicCalendar);
        }

        // GET: AcademicCalendar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicCalendar = await _context.AcademicCalendar.FindAsync(id);
            if (academicCalendar == null)
            {
                return NotFound();
            }
            return View(academicCalendar);
        }

        // POST: AcademicCalendar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Event, StartDate, EndDate")] AcademicCalendar academicCalendar)
        {
            if (id != academicCalendar.Id)
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
                    if (!AcademicCalendarExists(academicCalendar.Id))
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
            return View(academicCalendar);
        }

        // GET: AcademicCalendar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicCalendar = await _context.AcademicCalendar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicCalendar == null)
            {
                return NotFound();
            }

            return View(academicCalendar);
        }

        // POST: AcademicCalendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicCalendar = await _context.AcademicCalendar.FindAsync(id);
            _context.AcademicCalendar.Remove(academicCalendar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicCalendarExists(int id)
        {
            return _context.AcademicCalendar.Any(e => e.Id == id);
        }
    }
}

/* 23730 Léo Mermet */