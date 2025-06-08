using E_Attend.Entities.AuthenticationModels;

namespace E_Attend.Service.Authentication;

public interface IAuthenticationService
{
    public Task<AuthenticationModel> LoginAsync(LoginModel model);
    public Task<AuthenticationModel> RegisterAdminAsync(StudentRegisterModel model);
    public Task<AuthenticationModel> RegisterInstructorAsync(InstructorRegisterModel model);
    public Task<AuthenticationModel> RegisterAdminAsync(RegisterModel model);
}