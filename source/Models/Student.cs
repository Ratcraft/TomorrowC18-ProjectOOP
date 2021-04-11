using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Student : Profile
    {
        [Required]
        protected string group {get; set; }

        [Required]
        protected int progress {get; set; }

        [Required]
        protected Dictionary<string, double> subjectList {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/