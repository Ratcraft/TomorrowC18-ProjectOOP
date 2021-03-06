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
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Profile> userManager;

        public EventsController(Context context, UserManager<Profile> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<CalendarEvent> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return from e in _context.CalendarEvent where !((e.End <= start) || (e.Start >= end)) select e;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.CalendarEvent.SingleOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] CalendarEvent @event)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != @event.Id)
                {
                    return BadRequest();
                }

                _context.Entry(@event).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(id))
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

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] CalendarEvent @event)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.CalendarEvent.Add(@event);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
            }
            return NoContent();
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var @event = await _context.CalendarEvent.SingleOrDefaultAsync(m => m.Id == id);
                if (@event == null)
                {
                    return NotFound();
                }

                _context.CalendarEvent.Remove(@event);
                await _context.SaveChangesAsync();

                return Ok(@event);
            }
            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.CalendarEvent.Any(e => e.Id == id);
        }

        // PUT: api/Events/5/move
        [HttpPut("{id}/move")]
        public async Task<IActionResult> MoveEvent([FromRoute] int id, [FromBody] EventMoveParams param)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var @event = await _context.CalendarEvent.SingleOrDefaultAsync(m => m.Id == id);
                if (@event == null)
                {
                    return NotFound();
                }

                @event.Start = param.Start;
                @event.End = param.End;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(id))
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

        // PUT: api/Events/5/color
        [HttpPut("{id}/color")]
        public async Task<IActionResult> SetEventColor([FromRoute] int id, [FromBody] EventColorParams param)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            Profile user = userManager.FindByIdAsync(userid).Result;
            if (user.levelAccess != 1)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var @event = await _context.CalendarEvent.SingleOrDefaultAsync(m => m.Id == id);
                if (@event == null)
                {
                    return NotFound();
                }

                @event.Color = param.Color;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(id))
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
    }

    public class EventMoveParams
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class EventColorParams
    {
        public string Color { get; set; }
    }
}

/* 23730 Léo Mermet */