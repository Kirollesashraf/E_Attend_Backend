using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service._Instructor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _instructorService;
    public InstructorController(IInstructorService instructorService) => _instructorService = instructorService;


    [HttpGet]
    public async Task<IActionResult> GetAllInstructorAsync() =>
        Ok(await _instructorService.GetAllInstructorAsync());

    [HttpDelete("{instructorId}")]
    public async Task<IActionResult> DeleteInstructorAsync(string instructorId) =>
        Ok(await _instructorService.DeleteInstructorAsync(instructorId));


    [HttpPut("{instructorId}")]
    public async Task<IActionResult>
        UpdateInstructorAsync(string instructorId, [FromBody] UpdateInstructorDto updatedInstructor) =>
        Ok(await _instructorService.UpdateInstructorAsync(instructorId, updatedInstructor));
}