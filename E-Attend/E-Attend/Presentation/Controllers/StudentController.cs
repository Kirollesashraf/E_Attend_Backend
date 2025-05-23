﻿using E_Attend.Service.Attendance;
using E_Attend.Service.Course;
using E_Attend.Service.Lecture;
using E_Attend.Service.Sheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Student")]
[Route("student")]
[ApiController]
public class StudentController : ControllerBase {
    private readonly ISheetService _sheetService;
    private readonly ICourseService _courseService;
    private IAttendanceService _attendanceService;
    private ILectureService _lectureService;

    public StudentController(ICourseService courseService, ISheetService sheetService,
        IAttendanceService attendanceService, ILectureService lectureService) {
        _sheetService = sheetService;
        _courseService = courseService;
        _attendanceService = attendanceService;
        _lectureService = lectureService;
    }
    
    [HttpGet("lectures/student/{studentId}/course/{courseId}")]
    public async Task<IActionResult> GetStudentAttendLectures(string studentId, string courseId) => Ok(await _lectureService.GetStudentAttendLecture(studentId, courseId));

    [HttpGet("attendance/{attendanceId}")]
    public async Task<IActionResult> ViewAttendance(string attendanceId) =>
        Ok(await _attendanceService.ViewAttendanceAsync(attendanceId));

    //[HttpPost("sheets/{sheetId}/upload")]
    //public async Task<IActionResult> UploadSheet(int sheetId, [FromBody] byte[] fileData) =>
    //    Ok(await _sheetService.UploadSheetAsync(sheetId, fileData));

    [HttpGet("courses/student/{studentId}")]
    public async Task<IActionResult> ViewCoursesByStudentId(string studentId) =>
        Ok(await _courseService.ViewAllCoursesByStudentIDAsync(studentId));
}