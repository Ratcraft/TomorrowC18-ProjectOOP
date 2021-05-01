using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Profile : IdentityUser
    {

        [Required]
        public string firstName {get; set; }

        [Required]
        public string lastName {get; set; }

        [Required]
        public string birthDate {get; set; }

        [Required]
        public string sex {get; set; }

        [Required]
        [Range(1, 3)]
        private int levelAccess {get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/