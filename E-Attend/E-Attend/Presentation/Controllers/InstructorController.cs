using E_Attend.Entities.Models;
using E_Attend.Service.Instructor;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/instructor")]
[ApiController]
public class InstructorController : ControllerBase {
    private readonly IInstructorService _instructorService;

    public InstructorController(IInstructorService instructorService) {
        this._instructorService = instructorService;
    }

    [HttpPost("/add-instructor")]
    public async Task<IActionResult> Add([FromBody] Instructor instructor) =>
        Ok(await _instructorService.AddInstructorAsync(instructor));

    [HttpPost("/update-instructor/{instructorId}")]
    public async Task<IActionResult> Update(int instructorId, [FromBody] Instructor updatedInstructor) =>
        Ok(await _instructorService.UpdateInstructorAsync(instructorId, updatedInstructor));

    [HttpPost("/view-all-instructors")]
    public async Task<OkObjectResult> ViewAll() =>
        Ok(await _instructorService.ViewAllInstructorsAsync());

    [HttpPost("/delete-instructor/{instructorId}")]
    public async Task<IActionResult> Delete(int instructorId) =>
        Ok(await _instructorService.DeleteInstructorAsync(instructorId));
}