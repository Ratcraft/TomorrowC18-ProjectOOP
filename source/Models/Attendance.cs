using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OOP_moodle.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int FacultyId { get; set; }
        public string Status { get; set; }
    }
}

/*
Edited by Tony
*/