using System;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public abstract class Profile
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
        [Range(1, 3)]
        private int levelAccess {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/