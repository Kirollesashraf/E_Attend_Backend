using E_Attend.Entities.AuthenticationModels;
using E_Attend.Service._Authentication;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<AuthenticationModel> LoginAsync(LoginModel model) =>
        await _authenticationService.LoginAsync(model);

    [HttpPost("register/admin")]
    public async Task<AuthenticationModel> RegisterAdminAsync(RegisterModel model) =>
        await _authenticationService.RegisterAdminAsync(model);

    [HttpPost("register/instructor")]
    public async Task<AuthenticationModel> RegisterInstructorAsync(InstructorRegisterModel model) =>
        await _authenticationService.RegisterInstructorAsync(model);

    [HttpPost("register/student")]
    public async Task<AuthenticationModel> RegisterStudentAsync(StudentRegisterModel model) =>
        await _authenticationService.RegisterStudentAsync(model);
}