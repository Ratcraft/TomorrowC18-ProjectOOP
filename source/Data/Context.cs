using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AcademicCalendar> AcademicCalendar { get; set; }
        public DBSet<Course> Course {get; set; }
        public DBSet<Attendance> Attendance {get; set; }
        public DBSet<Fee> Fee {get; set; }
    }
}