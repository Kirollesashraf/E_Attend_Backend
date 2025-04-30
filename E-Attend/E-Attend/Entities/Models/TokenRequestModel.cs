using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models;

public class TokenRequestModel {
    [EmailAddress, Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}