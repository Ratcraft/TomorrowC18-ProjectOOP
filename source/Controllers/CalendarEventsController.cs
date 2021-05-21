using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace TomorrowC18ProjectOOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventsController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<Profile> userManager;

        public CalendarEventsController(Context context, UserManager<Profile> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }

        // GET: api/CalendarEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Events>>> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return await _context.Events
                .Where(e => !((e.End <= start) || (e.Start >= end)))
                .ToListAsync();
        }

        // GET: api/CalendarEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetCalendarEvent(int id)
        {
            var calendarEvent = await _context.Events.FindAsync(id);

            if (calendarEvent == null)
            {
                return NotFound();
            }

            return calendarEvent;
        }

        // PUT: api/CalendarEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarEvent(int id, CalendarEvent calendarEvent)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                if (id != calendarEvent.Id)
                {
                    return BadRequest();
                }

                _context.Entry(calendarEvent).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarEventExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            return NoContent();
        }

        // POST: api/CalendarEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Events>> PostCalendarEvent(Events calendarEvent)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                _context.Events.Add(calendarEvent);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCalendarEvent", new { id = calendarEvent.Id }, calendarEvent);
            }
            return NoContent();
        }

        // DELETE: api/CalendarEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarEvent(int id)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                var calendarEvent = await _context.Events.FindAsync(id);
                if (calendarEvent == null)
                {
                    return NotFound();
                }

                _context.Events.Remove(calendarEvent);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            return NoContent();
        }

        private bool CalendarEventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
/* 23730 Léo Mermet */