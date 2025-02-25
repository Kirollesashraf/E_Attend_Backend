using E_Attend.Entities.Models;
using E_Attend.Service.Submission;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/submission")]
[ApiController]
public class SubmissionController : ControllerBase {
    private readonly ISubmissionService _submissionService;

    public SubmissionController(ISubmissionService submissionService) {
        this._submissionService = submissionService;
    }

    [HttpPost("/add-submission")]
    public async Task<IActionResult> Add([FromBody] Submission submission) =>
        Ok(await _submissionService.AddSubmissionAsync(submission));

    [HttpPost("/update-submission/{submissionId}")]
    public async Task<IActionResult> Update(int submissionId, [FromBody] Submission updatedSubmission) =>
        Ok(await _submissionService.UpdateSubmissionAsync(submissionId, updatedSubmission));

    [HttpPost("/view-submission-by-student-id/{studentId}")]
    public async Task<OkObjectResult> ViewByStudentId(int studentId) =>
        Ok(await _submissionService.ViewAllSubmissionsOfStudentAsync(studentId));

    [HttpPost("/delete-submission/{submissionId}")]
    public async Task<IActionResult> Delete(int submissionId) =>
        Ok(await _submissionService.DeleteSubmissionAsync(submissionId));
}