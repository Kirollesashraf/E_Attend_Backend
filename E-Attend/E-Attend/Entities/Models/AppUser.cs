using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace E_Attend.Entities.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public DateTime CreatedAt { get; set; }


        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
