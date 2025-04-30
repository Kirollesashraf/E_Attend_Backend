using Microsoft.Build.Framework;

namespace E_Attend.Entities.Models;

public class AddRoleModel {
    [Required] 
    public string UserId { get; set; }
    [Required] 
    public string RoleName { get; set; }
}