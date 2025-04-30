using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Attend.Entities.ConfigurationModels;
using E_Attend.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace E_Attend.Service.Auth;

public class AuthService : IAuthService {
    private readonly UserManager<AppUser> _userManager;
    private readonly JWTOptions _jwtOptions;

    public AuthService(UserManager<AppUser> userManager, IOptions<JWTOptions> jwtOptions) {
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<AuthModel> RegisterAsync(RegisterModel model) {
        if (await _userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthModel() { Message = "Email is already registered" };
        var user = new AppUser() {
            Email = model.Email
        };
        var res = await _userManager.CreateAsync(user, model.Paswword);

        if (!res.Succeeded) {
            var errors = String.Empty;
            foreach (var error in res.Errors) {
                errors += $"{error.Description}, ";
            }

            return new AuthModel() { Message = errors };
        }

        await _userManager.AddToRoleAsync(user, "User");

        var jwtSecurityToken = await CreateJwtToken(user);
        return new AuthModel() {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            Roles = ["User"],
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };
    }

    public async Task<JwtSecurityToken> CreateJwtToken(AppUser user) {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim("roles", role));

        var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwtOptions.DurationInDays),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}