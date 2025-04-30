using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using E_Attend.Service.Auth;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("[controller]")]
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
    
    [HttpPost("token")]
    public async Task<IActionResult> GetTokenAsync(TokenRequestModel model) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await _authService.GetTokenAsync(model);
        if (!res.IsAuthenticated)
            return BadRequest(res.Message);

        return Ok(res);
    }
    
}