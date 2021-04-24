using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Fee
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public int facultyId { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        public DateTime deadline { get; set; }

        [Required]
        public string description { get; set; }
    }
}


/*
Edited by Tony
*/