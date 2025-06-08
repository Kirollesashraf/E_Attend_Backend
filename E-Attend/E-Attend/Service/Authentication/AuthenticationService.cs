using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;
using E_Attend.Entities.AuthenticationModels;
using E_Attend.Entities.OptionModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace E_Attend.Service.Authentication;

public class AuthenticationService : IAuthenticationService
{
   private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtOptions _jwtOptions;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationService(UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork) {
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
        _unitOfWork = unitOfWork;
        _roleManager = roleManager;
    }

    public async Task<AuthenticationModel> RegisterAdminAsync(RegisterModel model) {
        if (await _userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthenticationModel() { Message = "Email is already registered" };
        
        var user = new ApplicationUser() {
            Email = model.Email,
            
        };
        var res = await _userManager.CreateAsync(user, model.Password);

        if (!res.Succeeded) {
            var errors = res.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Description}, ");

            return new AuthenticationModel() { Message = errors };
        }

        if (! await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        await _userManager.AddToRoleAsync(user, "Admin");

        var jwtSecurityToken = await CreateJwtToken(user);
        return new AuthenticationModel() {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            UserId = user.Id,
            Roles = ["User"],
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };
    }
    public async Task<AuthenticationModel> RegisterInstructorAsync(InstructorRegisterModel model) {
        if (await _userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthenticationModel() { Message = "Email is already registered" };
        
        var user = new ApplicationUser() {
            Email = model.Email,
            
        };
        var res = await _userManager.CreateAsync(user, model.Password);

        if (!res.Succeeded) {
            var errors = res.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Description}, ");

            return new AuthenticationModel() { Message = errors };
        }

        if (! await _roleManager.RoleExistsAsync("Instructor"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Instructor"));
        }

        await _userManager.AddToRoleAsync(user, "Instructor");

        _unitOfWork.InstructorRepository.AddAsync(new Instructor()
        {
            Degree = model.Degree,
            Department = model.Department,
            Id = Guid.CreateVersion7().ToString(),
            UserId = user.Id,
            UniversityId = model.UniversityId,
            Name = model.Name,
            Specialization = model.Specialization
        });
        await _unitOfWork.CompleteAsync();
        
        var jwtSecurityToken = await CreateJwtToken(user);
        return new AuthenticationModel() {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            UserId = user.Id,
            Roles = ["User"],
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };
    }
    
    
    public async Task<AuthenticationModel> RegisterAdminAsync(StudentRegisterModel model) {
        if (await _userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthenticationModel() { Message = "Email is already registered" };
        
        var user = new ApplicationUser() {
            Email = model.Email,
            
        };
        var res = await _userManager.CreateAsync(user, model.Password);

        if (!res.Succeeded) {
            var errors = res.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Description}, ");

            return new AuthenticationModel() { Message = errors };
        }

        if (! await _roleManager.RoleExistsAsync("Student"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Student"));
        }

        _unitOfWork.StudentRepository.AddAsync(new Student()
        {
            Name = model.Name,
            Degree = model.Degree,
            Department = model.Department,
            Id = Guid.CreateVersion7().ToString(),
            UserId = user.Id,
        });
        await _unitOfWork.CompleteAsync();
        await _userManager.AddToRoleAsync(user, "Student");

        var jwtSecurityToken = await CreateJwtToken(user);
        return new AuthenticationModel() {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            UserId = user.Id,
            Roles = ["User"],
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };
    }

    public async Task<AuthenticationModel> LoginAsync(LoginModel model)
    {
        var authModel = new AuthenticationModel();

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
        authModel.UserId = user.Id;
        authModel.ExpiresOn = jwtSecurityToken.ValidTo;
        authModel.Roles = rolesList.ToList();

        return authModel;
    }
    

    public async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user) {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = roles.Select(role => new Claim("roles", role)).ToList();

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