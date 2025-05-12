using System.Security.Claims;
using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using E_Attend.Service.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) {
        _authService = authService;
    }

    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterModel model) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await _authService.RegisterAsync(model);
        if (!res.IsAuthenticated)
            return BadRequest(res.Message);

        return Ok(res);
    }   
    
    // [Authorize("Admin")] NOT SAFE 
    [HttpPost("token")]
    public async Task<IActionResult> GetTokenAsync(TokenRequestModel model) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await _authService.GetTokenAsync(model);
        if (!res.IsAuthenticated)
            return BadRequest(res.Message);

        return Ok(res);
    }
    
    //[Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpPost("add-role")]
    public async Task<IActionResult> AddRoleAsync(AddRoleModel model) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await _authService.AddRoleAsync(model);
        if (!string.IsNullOrEmpty(res))
            return BadRequest(res);

        return Ok($"Role {model.RoleName} assigned successfully" );
    }
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("debug-role")]
    public IActionResult DebugUserRole()
    {
        var userName = User.Identity?.Name ?? "Unknown";
        var isAuthenticated = User.Identity?.IsAuthenticated ?? false;
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        return Ok(new
        {
            isAuthenticated,
            userName,
            roles
        });
    }

    
    
}