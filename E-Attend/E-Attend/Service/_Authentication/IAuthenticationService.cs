using E_Attend.Entities.AuthenticationModels;

namespace E_Attend.Service._Authentication;

public interface IAuthenticationService
{
    public Task<AuthenticationModel> LoginAsync(LoginModel model);
    public Task<AuthenticationModel> RegisterStudentAsync(StudentRegisterModel model);
    public Task<AuthenticationModel> RegisterInstructorAsync(InstructorRegisterModel model);
    public Task<AuthenticationModel> RegisterAdminAsync(RegisterModel model);
}