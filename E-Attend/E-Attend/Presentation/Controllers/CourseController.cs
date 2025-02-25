using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

using E_Attend.Service.Course;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/course")]
// [Area(StaticData.Instructor)]
// [Authorize(Roles = StaticData.Instructor)]
[ApiController]
public class CourseController : ControllerBase {
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService) {
        this._courseService = courseService;
    }

    [HttpPost("/view-course-by-student-id/{studentId}")]
    public async Task<OkObjectResult> ViewByStudentId(int studentId) =>
        Ok(await _courseService.ViewAllCoursesByStudentIDAsync(studentId));

    [HttpPost("/create-course")]
    public async Task<IActionResult> Create([FromBody] Course newCourse) =>
        Ok(await _courseService.AddCourseAsync(newCourse));
    [HttpPost("/delete-course/{courseId}")]
    public async Task<IActionResult> Delete(int courseId) =>
        Ok(await _courseService.DeleteCourseAsync(courseId));

    [HttpPost("/update-course/{courseId}")]
    public async Task<IActionResult> Update(int courseId, [FromBody] Course newCourse) =>
        Ok(await _courseService.UpdateCourseAsync(courseId,
            newCourse));



}