using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;

namespace TomorrowC18ProjectOOP.Controllers
{
    public class AcademicCalendarController : Controller
    {
        private readonly Context _context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Event, Date")] AcademicCalendar academicCalendar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicCalendar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicCalendar);
        }
    }
}
