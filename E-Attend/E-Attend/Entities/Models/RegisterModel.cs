using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models;

public class RegisterModel {

    [Required, StringLength(50)]
    public string Username { get; set; }

    [EmailAddress, Required, StringLength(128)]
    public string Email { get; set; }

    [Required, StringLength(256)]
    public string Password { get; set; }
    
    
}