using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Student : Profile
    {
        [Required]
        public string group {get; set; }

        [Required]
        public int progress {get; set; }

        [Required]
        public string subjectList {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/