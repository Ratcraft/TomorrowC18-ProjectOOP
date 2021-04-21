using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }
        public int teacherId { get; set; }
        public DateTime begin { get; set; }
        public DateTime end { get; set; }
        public string courseName { get; set; }
        public string description { get; set; }
    }
}

/*
Edited by Tony
*/