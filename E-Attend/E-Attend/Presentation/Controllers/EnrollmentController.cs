using E_Attend.Entities.Models;
using E_Attend.Service.Enrollment;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/enrollment")]
[ApiController]
public class EnrollmentController : ControllerBase {
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentController(IEnrollmentService enrollmentService) {
        this._enrollmentService = enrollmentService;
    }

    [HttpPost("/enroll-course")]
    public async Task<IActionResult> Enroll(int studentId, int courseId) =>
        Ok(await _enrollmentService.EnrollCourseAsync(studentId, courseId));

    [HttpPost("/update-enrollment/{enrollmentId}")]
    public async Task<IActionResult> Update(int enrollmentId, [FromBody] Enrollment updatedEnrollment) =>
        Ok(await _enrollmentService.UpdateEnrollmentAsync(enrollmentId, updatedEnrollment));

    [HttpPost("/view-enrollment-by-student-id/{studentId}")]
    public async Task<OkObjectResult> ViewByStudentId(int studentId) =>
        Ok(await _enrollmentService.ViewAllEnrollmentsOfStudentAsync(studentId));

    [HttpPost("/delete-enrollment/{enrollmentId}")]
    public async Task<IActionResult> Delete(int enrollmentId) =>
        Ok(await _enrollmentService.DeleteEnrollmentAsync(enrollmentId));
}