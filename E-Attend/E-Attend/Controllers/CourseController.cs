using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service._Course;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService) => _courseService = courseService;

    //===========================Course===========================
    [HttpPost]
    public async Task<IActionResult> AddCourseAsync([FromBody] Course course) =>
        Ok(await _courseService.AddCourseAsync(course));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseAsync(string id) => Ok(await _courseService.GetCourseAsync(id));

    [HttpGet]
    public async Task<IActionResult> GetCoursesAsync() => Ok(await _courseService.GetCoursesAsync());

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> RemoveCourseAsync(string courseId) =>
        Ok(await _courseService.RemoveCourseAsync(courseId));

    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateCourseAsync(string courseId, [FromBody] UpdateCourseDto updatedCourse) =>
        Ok(await _courseService.UpdateCourseAsync(courseId, updatedCourse));

    //===========================Announcement===========================
    [HttpPost("{courseId}/announcements")]
    public async Task<IActionResult> AddAnnouncementAsync(string courseId, [FromBody] Announcement announcement) =>
        Ok(await _courseService.AddAnnouncementAsync(courseId, announcement));

    [HttpGet("{courseId}/announcements")]
    public async Task<IActionResult> GetAnnouncementsAsync(string courseId) =>
        Ok(await _courseService.GetAnnouncementsAsync(courseId));

    [HttpDelete("{courseId}/announcements/{announcementId}")]
    public async Task<IActionResult> RemoveAnnouncementAsync(string courseId, string announcementId) =>
        Ok(await _courseService.RemoveAnnouncementAsync(courseId, announcementId));

    [HttpPut("announcements/{announcementId}")]
    public async Task<IActionResult> UpdateAnnouncementAsync(string announcementId,
        [FromBody] Announcement updatedAnnouncement) =>
        Ok(await _courseService.UpdateAnnouncementAsync(announcementId, updatedAnnouncement));

    //===========================Lecture===========================
    [HttpPost("{courseId}/lectures")]
    public async Task<IActionResult> AddLectureAsync(string courseId, [FromBody] Lecture lecture) =>
        Ok(await _courseService.AddLectureAsync(courseId, lecture));

    [HttpGet("{courseId}/lectures")]
    public async Task<IActionResult> GetLecturesAsync(string courseId) =>
        Ok(await _courseService.GetLecturesAsync(courseId));

    [HttpDelete("lectures/{lectureId}")]
    public async Task<IActionResult> RemoveLectureAsync(string lectureId) =>
        Ok(await _courseService.RemoveLectureAsync(lectureId));

    [HttpPut("lectures/{lectureId}")]
    public async Task<IActionResult> UpdateLectureAsync(string lectureId, [FromBody] Lecture updatedLecture) =>
        Ok(await _courseService.UpdateLectureAsync(lectureId, updatedLecture));

    //===========================Student===========================
    [HttpPost("{courseId}/students")]
    public async Task<IActionResult> AddStudentAsync(string courseId, [FromBody] Student student) =>
        Ok(await _courseService.AddStudentAsync(courseId, student));

    [HttpGet("{courseId}/students")]
    public async Task<IActionResult> GetStudentsAsync(string courseId) =>
        Ok(await _courseService.GetStudentsAsync(courseId));

    [HttpDelete("{courseId}/students/{studentId}")]
    public async Task<IActionResult> RemoveStudentAsync(string courseId, string studentId) =>
        Ok(await _courseService.RemoveStudentAsync(courseId, studentId));
}