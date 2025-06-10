using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service._Instructor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("[controller]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _instructorService;
    public InstructorController(IInstructorService instructorService) => _instructorService = instructorService;

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllInstructorAsync() =>
        Ok(await _instructorService.GetAllInstructorAsync());


    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
    [HttpGet("{instructorId}")]
    public async Task<IActionResult> GetInstructorAsync(string instructorId) =>
        Ok(await _instructorService.GetInstructorAsync(instructorId));

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [HttpDelete("{instructorId}")]
    public async Task<IActionResult> DeleteInstructorAsync(string instructorId) =>
        Ok(await _instructorService.DeleteInstructorAsync(instructorId));


    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [HttpPut("{instructorId}")]
    public async Task<IActionResult>
        UpdateInstructorAsync(string instructorId, [FromBody] UpdateInstructorDto updatedInstructor) =>
        Ok(await _instructorService.UpdateInstructorAsync(instructorId, updatedInstructor));
}