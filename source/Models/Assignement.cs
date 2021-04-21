using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Assignement
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public int studentId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
