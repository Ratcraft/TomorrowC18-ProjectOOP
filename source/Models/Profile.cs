using System;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public abstract class Profile
    {
        [Key]
        public int id {get; set; }

        [Required]
        public string firstName {get; set; }

        [Required]
        public string lastName {get; set; }

        [Required]
        public string birthDate {get; set; }

        [Required]
        public string sex {get; set; }

        [Required]
        public string userName {get; set; }

        [Required]
        public string emailAdress {get; set; }

        [Required]
        public string password {get; set; }

        public string passwordHash { get; set; }

        [Required]
        [Range(1, 3)]
        private int levelAccess {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/