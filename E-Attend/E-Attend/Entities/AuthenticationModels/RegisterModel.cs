using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.AuthenticationModels;

public class RegisterModel
{
    [EmailAddress, Required, StringLength(256)]
    public string Email { get; set; }

    [Required, StringLength(256)]
    public string Password { get; set; }
    
    [Required, StringLength(256)]
    public string Role { get; set; }

}