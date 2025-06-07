using Microsoft.AspNetCore.Identity;

namespace E_Attend.Entities;

public class ApplicationUser : IdentityUser
{
     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}