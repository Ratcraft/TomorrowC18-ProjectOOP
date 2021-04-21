using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OOP_moodle.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
}

/*
Edited by Tony
*/