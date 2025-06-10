using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service._Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService) => _courseService = courseService;

    //===========================Course===========================
    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddCourseAsync([FromBody] AddCourseDto course) =>
        Ok(await _courseService.AddCourseAsync(course));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin,Instructor,Student")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseAsync(string id) => Ok(await _courseService.GetCourseAsync(id));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetCoursesAsync() => Ok(await _courseService.GetCoursesAsync());

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpDelete("{courseId}")]
    public async Task<IActionResult> RemoveCourseAsync(string courseId) =>
        Ok(await _courseService.RemoveCourseAsync(courseId));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateCourseAsync(string courseId, [FromBody] UpdateCourseDto updatedCourse) =>
        Ok(await _courseService.UpdateCourseAsync(courseId, updatedCourse));

    //===========================Announcement===========================
    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Instructor,Admin")]
    [HttpPost("{courseId}/announcements")]
    public async Task<IActionResult> AddAnnouncementAsync(string courseId, [FromBody] AddAnnouncementDto announcement) =>
        Ok(await _courseService.AddAnnouncementAsync(courseId, announcement));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Instructor,Student,Admin")]
    [HttpGet("{courseId}/announcements")]
    public async Task<IActionResult> GetAnnouncementsAsync(string courseId) =>
        Ok(await _courseService.GetAnnouncementsAsync(courseId));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpDelete("{courseId}/announcements/{announcementId}")]
    public async Task<IActionResult> RemoveAnnouncementAsync(string courseId, string announcementId) =>
        Ok(await _courseService.RemoveAnnouncementAsync(courseId, announcementId));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Instructor,Admin")]
    [HttpPut("announcements/{announcementId}")]
    public async Task<IActionResult> UpdateAnnouncementAsync(string announcementId,
        [FromBody] UpdateAnnouncementDto updatedAnnouncement) =>
        Ok(await _courseService.UpdateAnnouncementAsync(announcementId, updatedAnnouncement));

    //===========================Lecture===========================
    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin,Instructor")]
    [HttpPost("{courseId}/lectures")]
    public async Task<IActionResult> AddLectureAsync(string courseId, [FromBody] AddLectureDto lecture) =>
        Ok(await _courseService.AddLectureAsync(courseId, lecture));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin,Instructor,Student")]
    [HttpGet("{courseId}/lectures")]
    public async Task<IActionResult> GetLecturesAsync(string courseId) =>
        Ok(await _courseService.GetLecturesAsync(courseId));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin,Instructor")]
    [HttpDelete("lectures/{lectureId}")]
    public async Task<IActionResult> RemoveLectureAsync(string lectureId) =>
        Ok(await _courseService.RemoveLectureAsync(lectureId));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin,Instructor")]
    [HttpPut("lectures/{lectureId}")]
    public async Task<IActionResult> UpdateLectureAsync(string lectureId, [FromBody] UpdateLectureDto updatedLecture) =>
        Ok(await _courseService.UpdateLectureAsync(lectureId, updatedLecture));

    //===========================Student===========================
    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpPost("{courseId}/students")]
    public async Task<IActionResult> AddStudentAsync(string courseId, string studentId) =>
        Ok(await _courseService.AddStudentAsync(courseId, studentId));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin,Instructor")]
    [HttpGet("{courseId}/students")]
    public async Task<IActionResult> GetStudentsAsync(string courseId) =>
        Ok(await _courseService.GetStudentsAsync(courseId));

    [Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
    [HttpDelete("{courseId}/students/{studentId}")]
    public async Task<IActionResult> RemoveStudentAsync(string courseId, string studentId) =>
        Ok(await _courseService.RemoveStudentAsync(courseId, studentId));
}