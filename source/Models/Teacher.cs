using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Teacher : Profile
    {
        [Required]
        protected string subject {get; set; }

        [Required]
        protected List<string> groupList {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/