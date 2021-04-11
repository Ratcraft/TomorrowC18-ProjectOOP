using TomorrowC18ProjectOOPclear.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class MvcBikeContext : DbContext
    {
        public Context(DbContextOptions<MvcBikeContext> options) : base(options)
        {

        }

        public DbSet<TomorrowC18ProjectOOP> Profile { get; set; }
        public DbSet<TomorrowC18ProjectOOP> Student { get; set; }
        public DbSet<TomorrowC18ProjectOOP> Teacher { get; set; }
        public DbSet<TomorrowC18ProjectOOP> Admin { get; set; }
    }
}