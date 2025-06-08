namespace E_Attend.Entities.AuthenticationModels;

public class InstructorRegisterModel : RegisterModel
{
    public string Name { get; set; }
    public string UniversityId { get; set; }
    public string Degree { get; set; }
    public string Specialization { get; set; }
    public string Department { get; set; }

}