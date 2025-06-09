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
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddCourseAsync([FromBody] AddCourseDto course) =>
        Ok(await _courseService.AddCourseAsync(course));

    [Authorize(Roles = "Admin,Instructor,Student")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseAsync(string id) => Ok(await _courseService.GetCourseAsync(id));

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetCoursesAsync() => Ok(await _courseService.GetCoursesAsync());

    [Authorize(Roles = "Admin")]
    [HttpDelete("{courseId}")]
    public async Task<IActionResult> RemoveCourseAsync(string courseId) =>
        Ok(await _courseService.RemoveCourseAsync(courseId));

    [Authorize(Roles = "Admin")]
    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateCourseAsync(string courseId, [FromBody] UpdateCourseDto updatedCourse) =>
        Ok(await _courseService.UpdateCourseAsync(courseId, updatedCourse));

    //===========================Announcement===========================
    [Authorize(Roles = "Instructor,Admin")]
    [HttpPost("{courseId}/announcements")]
    public async Task<IActionResult> AddAnnouncementAsync(string courseId, [FromBody] Announcement announcement) =>
        Ok(await _courseService.AddAnnouncementAsync(courseId, announcement));

    [Authorize(Roles = "Instructor,Student,Admin")]
    [HttpGet("{courseId}/announcements")]
    public async Task<IActionResult> GetAnnouncementsAsync(string courseId) =>
        Ok(await _courseService.GetAnnouncementsAsync(courseId));

    [Authorize(Roles = "Admin")]
    [HttpDelete("{courseId}/announcements/{announcementId}")]
    public async Task<IActionResult> RemoveAnnouncementAsync(string courseId, string announcementId) =>
        Ok(await _courseService.RemoveAnnouncementAsync(courseId, announcementId));

    [Authorize(Roles = "Instructor,Admin")]
    [HttpPut("announcements/{announcementId}")]
    public async Task<IActionResult> UpdateAnnouncementAsync(string announcementId,
        [FromBody] Announcement updatedAnnouncement) =>
        Ok(await _courseService.UpdateAnnouncementAsync(announcementId, updatedAnnouncement));

    //===========================Lecture===========================
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost("{courseId}/lectures")]
    public async Task<IActionResult> AddLectureAsync(string courseId, [FromBody] Lecture lecture) =>
        Ok(await _courseService.AddLectureAsync(courseId, lecture));

    [Authorize(Roles = "Admin,Instructor,Student")]
    [HttpGet("{courseId}/lectures")]
    public async Task<IActionResult> GetLecturesAsync(string courseId) =>
        Ok(await _courseService.GetLecturesAsync(courseId));

    [Authorize(Roles = "Admin,Instructor")]
    [HttpDelete("lectures/{lectureId}")]
    public async Task<IActionResult> RemoveLectureAsync(string lectureId) =>
        Ok(await _courseService.RemoveLectureAsync(lectureId));

    [Authorize(Roles = "Admin,Instructor")]
    [HttpPut("lectures/{lectureId}")]
    public async Task<IActionResult> UpdateLectureAsync(string lectureId, [FromBody] Lecture updatedLecture) =>
        Ok(await _courseService.UpdateLectureAsync(lectureId, updatedLecture));

    //===========================Student===========================
    [Authorize(Roles = "Admin")]
    [HttpPost("{courseId}/students")]
    public async Task<IActionResult> AddStudentAsync(string courseId, [FromBody] Student student) =>
        Ok(await _courseService.AddStudentAsync(courseId, student));

    [Authorize(Roles = "Admin,Instructor")]
    [HttpGet("{courseId}/students")]
    public async Task<IActionResult> GetStudentsAsync(string courseId) =>
        Ok(await _courseService.GetStudentsAsync(courseId));

    [Authorize(Roles = "Admin")]
    [HttpDelete("{courseId}/students/{studentId}")]
    public async Task<IActionResult> RemoveStudentAsync(string courseId, string studentId) =>
        Ok(await _courseService.RemoveStudentAsync(courseId, studentId));
}