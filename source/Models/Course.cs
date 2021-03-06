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
        [Required]
        public int id { get; set; }
        //[Required]
        public string teachername { get; set; }
        [Required]
        public string group { get; set; }
        [Required]
        public DateTime begin { get; set; }
        [Required]
        public int duration { get; set; }
        [Required]
        public string courseName { get; set; }
        public string description { get; set; }
    }
}

/*
Edited by Tony and Alexis
*/