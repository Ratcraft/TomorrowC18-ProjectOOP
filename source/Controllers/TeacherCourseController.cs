﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TomorrowC18ProjectOOP.Controllers
{
    [Authorize(Roles = "Teacher,Admin")]
    public class TeacherCourseController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Profile> userManager;
        public TeacherCourseController(Context context, UserManager<Profile> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }

        // GET: Course
        public async Task<IActionResult> Index(string searchString)
        {
            var courses = from currentMovieItem in _context.Course select currentMovieItem;

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.courseName.Contains(searchString)); // still deferred, but query updated
            }

            var teachercoursevm = new TeacherCourseVM
            {
                courses = await courses.ToListAsync()

            };

            return View(teachercoursevm);
        }

        public async Task<IActionResult> TeacherIndex()
        {
            var course = await _context.Course.ToListAsync();
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;

            List<Course> result = new List<Course>();
            foreach (var item in course)
            {
                if (item.teachername == user.UserName) { result.Add(item); }
            }

            return View(result);
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,teachername,group,begin,duration,courseName,description")] Course course)
        {
            if (ModelState.IsValid)
            {
                /*
                var userid = userManager.GetUserId(HttpContext.User);
                Profile user = userManager.FindByIdAsync(userid).Result;
                course.teachername = user.UserName;*/
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeacherCreate([Bind("id,teachername,group,begin,duration,courseName,description")] Course course)
        {
            if (ModelState.IsValid)
            {
                var userid = userManager.GetUserId(HttpContext.User);
                Profile user = userManager.FindByIdAsync(userid).Result;
                course.teachername = user.UserName;
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,teachername,group,begin,duration,courseName,description")] Course course)
        {
            if (id != course.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.id))
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
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.id == id);
        }
    }
}

/*Edited by 23749 Tony Fiori*/
