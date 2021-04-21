using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OOP_moodle.Models
{
    public class Fee
    {
        [Key]
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

/*
Edited by Tony
*/