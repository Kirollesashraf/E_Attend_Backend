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
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(UserManager<AppUser> userManager, IOptions<JWTOptions> jwtOptions, RoleManager<IdentityRole> roleManager) {
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
        _roleManager = roleManager;
    }

    public async Task<AuthModel> RegisterAsync(RegisterModel model) {
        if (await _userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthModel() { Message = "Email is already registered" };
        
        if (await _userManager.FindByNameAsync(model.Username) is not null)
            return new AuthModel() { Message = "Username is already registered" };
        
        var user = new AppUser() {
            Email = model.Email,
            UserName = model.Username,
            
        };
        var res = await _userManager.CreateAsync(user, model.Password);

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

    public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
    {
        var authModel = new AuthModel();

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            authModel.Message = "Email or Password is incorrect!";
            return authModel;
        }

        var jwtSecurityToken = await CreateJwtToken(user);
        var rolesList = await _userManager.GetRolesAsync(user);

        authModel.IsAuthenticated = true;
        authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        authModel.Email = user.Email;
        authModel.Username = user.UserName;
        authModel.ExpiresOn = jwtSecurityToken.ValidTo;
        authModel.Roles = rolesList.ToList();

        return authModel;
    }

    public async Task<string> AddRoleAsync(AddRoleModel model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId);

        if (user is null || !await _roleManager.RoleExistsAsync(model.RoleName))
            return "Invalid user ID or Role";

        if (await _userManager.IsInRoleAsync(user, model.RoleName))
            return "User already assigned to this role";

        var result = await _userManager.AddToRoleAsync(user, model.RoleName);

        return result.Succeeded ? string.Empty : "Something went wrong";
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