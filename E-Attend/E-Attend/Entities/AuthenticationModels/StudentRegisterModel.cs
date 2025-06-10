using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.AuthenticationModels;

public class StudentRegisterModel : RegisterModel
{

    public string UserId { get; set; }
    public string Name { get; set; }
    public string Degree { get; set; }
    public string Department { get; set; }

}