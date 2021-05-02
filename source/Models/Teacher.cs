using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Teacher : Profile
    {
        [Required]
        public string subject {get; set; }

        [Required]
        public string groupList {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/