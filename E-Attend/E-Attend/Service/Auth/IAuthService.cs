using E_Attend.Entities.Models;

namespace E_Attend.Service.Auth;

public interface IAuthService {
    Task<AuthModel> RegisterAsync(RegisterModel model);
}