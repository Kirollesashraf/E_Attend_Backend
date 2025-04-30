using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models;

public class RegisterModel {
    [EmailAddress, MaxLength(128)]
    public string Email { get; set; }
    [MaxLength(50)]
    public string Paswword { get; set; }
}