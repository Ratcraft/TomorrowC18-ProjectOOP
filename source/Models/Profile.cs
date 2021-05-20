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
        [Range(1, 3)] /* 1 = Student, 2 = Teacher, 3 = Admin */
        public int levelAccess {get; set; }

        public string subject { get; set; }

        public string groupList { get; set; }
        [Required]
        public string group { get; set; }
        [Required]
        public int progress { get; set; }

        public string subjectList { get; set; }
    }
}

/*
Edited by Thibault and Anjara
*/