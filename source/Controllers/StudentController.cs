using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TomorrowC18ProjectOOP.Controllers
{
    public class StudentController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Profile> userManager;
        public StudentController(Context context, UserManager<Profile> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            var examList = await _context.Exam.ToListAsync();

            List<string> subjects = user.subjectList.Split(new char[] { ',' }).ToList();

            Dictionary<String, List<Exam>> grades = new Dictionary<string, List<Exam>>();
            foreach (string subject in subjects)
            {
                List<Exam> exams = new List<Exam>();
                grades.Add(subject, exams);
            }

            foreach (var item in examList)
            {
                if (grades.ContainsKey(item.CourseName) && item.StudentId.ToString() == userid)
                {
                    grades[item.CourseName].Add(item);
                }
            }

            return View(grades);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id, firstName, lastName, birthDate, sex, userName, emailAdress, password, passwordHash, levelAccess, group, progress, subjectList")] Profile student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Profile.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id, firstName, lastName, birthDate, sex, userName, emailAdress, password, passwordHash, levelAccess, group, progress, subjectList")] Profile student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // POST: student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Profile.FindAsync(id);
            _context.Profile.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Profile.Any(e => e.Id == id);
        }
    }
}

/*
 * Edited by Alexis/Thibault
*/