using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Form
    {
        [Key]
        [Required]
        public int id {get; set; }

        [Required]
        public string email {get; set; }

        [Required]
        public string requestType {get; set; }

        [Required]
        public string requestMessage{get; set; }
    }
}