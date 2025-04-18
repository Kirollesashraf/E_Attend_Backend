﻿using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class AppUser
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)] 
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }


        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
