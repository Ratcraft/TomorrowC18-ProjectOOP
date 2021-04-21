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
        public int id { get; set; }
        public int facultyId { get; set; }
        public int amount { get; set; }
        public DateTime paymentDate { get; set; }
    }
}


/*
Edited by Tony
*/