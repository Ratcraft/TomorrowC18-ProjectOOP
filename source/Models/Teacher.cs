using System;

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