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
        public int id { get; set; }
        public int courseId { get; set; }
        public int facultyId { get; set; }
        public string status { get; set; }
    }
}

/*
Edited by Tony
*/