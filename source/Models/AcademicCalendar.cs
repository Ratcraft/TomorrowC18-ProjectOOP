using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class AcademicCalendar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Event { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}

/* 23730 Léo Mermet */