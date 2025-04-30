using System.IdentityModel.Tokens.Jwt;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Auth;

public interface IAuthService {
    Task<AuthModel> RegisterAsync(RegisterModel model);
    Task<JwtSecurityToken> CreateJwtToken(AppUser user);
    public Task<AuthModel> GetTokenAsync(TokenRequestModel model);
}