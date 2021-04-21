using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Attendance
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public int courseId { get; set; }
        [Required]
        public int facultyId { get; set; }
        public string status { get; set; }
    }
}

/*
Edited by Tony
*/