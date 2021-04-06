using System;

namespace Models
{
    public class Profile
    {
        [Required]
        protected string firstName {get; set; }

        [Required]
        protected string lastName {get; set; }

        [Required]
        protected string birthDate {get; set; }

        [Required]
        protected string sex {get; set; }

        [Required]
        protected string userName {get; set; }

        [Required]
        protected string emailAdress {get; set; }

        [Required]
        private int levelAccess {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/