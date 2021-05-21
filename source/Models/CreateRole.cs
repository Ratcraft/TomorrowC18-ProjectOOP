using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CreateRole
    {
        [Required]
        public string roleName { get; set; }
    }
}
// Edited by Louis Ribault 23732