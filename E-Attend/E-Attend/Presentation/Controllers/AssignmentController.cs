using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Service.Assignment;
using E_Attend.Service.Assignment.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/assignment")]
// [Area(StaticData.Instructor)]
// [Authorize(Roles = StaticData.Instructor)]
[ApiController]
public class AssignmentController : ControllerBase {
    private readonly IAssignmentService _assignmentService;

    public AssignmentController(IAssignmentService assignmentService) {
        this._assignmentService = assignmentService;
    }

    [HttpPost("/view/{assignmentId}")]
    public async Task<OkObjectResult> ViewAssignment(int assignmentId) =>
        Ok(await _assignmentService.ViewAssignmentAsync(assignmentId));

    [HttpPost("/create")]
    public async Task<IActionResult> CreateAssignment([FromBody] AssignmentDTO assignment) =>
        Ok(await _assignmentService.CreateAssignmentAsync(assignment));
    [HttpPost("/delete/{assignmentId}")]
    public async Task<IActionResult> DeleteAssignment(int assignmentId) =>
        Ok(await _assignmentService.DeleteAssignmentAsync(assignmentId));

    [HttpPost("/update/{assignmentId}")]
    public async Task<IActionResult> UpdateAssignmentDescription(int assignmentId, [FromBody] AssignmentDTO newDescription) =>
        Ok(await _assignmentService.UpdateAssignment(assignmentId,
            newDescription));


    
    
    [HttpPost("/view-all-by-instructor-id/{instructorId}")]
    public async Task<IActionResult> ViewAllAssignmentsByInstructorId(int instructorId) =>
        Ok(await _assignmentService.ViewAllAssignmentsByInstructorIdAsync(instructorId));
}