using E_Attend.Entities.DTOs;
using E_Attend.Service.Assignment;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/instructor")]
[ApiController]
public class InstructorController : ControllerBase {
    private readonly IInstructorServicesOrchestrator _instructorServicesOrchestrator;

    public InstructorController(IInstructorServicesOrchestrator instructorServicesOrchestrator) {
        this._instructorServicesOrchestrator = instructorServicesOrchestrator;
    }

    [HttpPost("/view-assignment/{assignmentId}")]
    public async Task<OkObjectResult> CreateAssignment(int assignmentId) =>
        Ok(await _instructorServicesOrchestrator.AssignmentService.ViewAssignmentAsync(assignmentId));

    [HttpPost("/create-assignment")]
    public async Task<IActionResult> CreateAssignment([FromBody] AssignmentDTO assignment) =>
        Ok(await _instructorServicesOrchestrator.AssignmentService.CreateAssignmentAsync(assignment));
    [HttpPost("/delete-assignment/{assignmentId}")]
    public async Task<IActionResult> DeleteAssignment(int assignmentId) =>
        Ok(await _instructorServicesOrchestrator.AssignmentService.DeleteAssignmentAsync(assignmentId));

    [HttpPost("/update-assignment-description/{assignmentId}")]
    public async Task<IActionResult> UpdateAssignmentDescription(int assignmentId, [FromBody] string newDescription) =>
        Ok(await _instructorServicesOrchestrator.AssignmentService.UpdateDescriptionAsync(assignmentId,
            newDescription));

    [HttpPost("/update-assignment-due-date/{assignmentId}")]
    public async Task<IActionResult> UpdateAssignmentDueDate(int assignmentId, [FromBody] DateTime newDate) =>
        Ok(await _instructorServicesOrchestrator.AssignmentService.UpdateDueDateAsync(assignmentId, newDate));

    [HttpPost("/update-assignment-title/{assignmentId}")]
    public async Task<IActionResult> UpdateAssignmentTitle(int assignmentId, [FromBody] string newTitle) =>
        Ok(await _instructorServicesOrchestrator.AssignmentService.UpdateTitleAsync(assignmentId, newTitle));
}