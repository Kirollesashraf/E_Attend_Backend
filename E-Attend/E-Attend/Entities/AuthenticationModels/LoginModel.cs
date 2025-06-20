﻿using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.AuthenticationModels;

public class LoginModel
{
    [EmailAddress, Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}