using E_Attend.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Attend.Service.Auth;

public class AuthService : IAuthService {
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager) {
        _userManager = userManager;
    }
    public Task<AuthModel> RegisterAsync(RegisterModel model) {
        throw new NotImplementedException();
    }
}