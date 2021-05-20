using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data
{
    public class Context : IdentityDbContext<Profile>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AcademicCalendar> AcademicCalendar { get; set; }
        public DbSet<CalendarEvent> CalendarEvent { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<Assignement> Assignement { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Form> Form {get; set; }
    }
}