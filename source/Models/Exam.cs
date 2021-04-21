using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TomorrowC18ProjectOOP.Models
{
    public class Exam
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public double Grade { get; set; }
        
    }
}

/*
Edited by Tony
*/