using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TomorrowC18ProjectOOP.Models
{
    public class Result
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public double Average { get; set; }
    }
}

/*
Edited by Tony
*/