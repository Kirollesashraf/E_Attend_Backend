using E_Attend.Service._Attendance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    
    [Authorize(Roles = "Admin,Student")]
    [HttpGet("student/{courseId}/{studentId}")]
    public async Task<IActionResult> GetStudentAttendanceInCourseAsync(string courseId, string studentId) =>
        Ok(await _attendanceService.GetStudentAttendanceInCourseAsync(courseId, studentId));

    [Authorize(Roles = "Admin,Instructor")]
    [HttpGet("scheduled/{courseId}")]
    public async Task<IActionResult> GetScheduledAttendanceAsync(string courseId) =>
        Ok(await _attendanceService.GetScheduledAttendanceAsync(courseId));

    [Authorize(Roles = "Admin,Instructor")]
    [HttpGet("unscheduled/{courseId}")]
    public async Task<IActionResult> GetUnscheduledAttendanceAsync(string courseId) =>
        Ok(await _attendanceService.GetUnscheduledAttendanceAsync(courseId));
}