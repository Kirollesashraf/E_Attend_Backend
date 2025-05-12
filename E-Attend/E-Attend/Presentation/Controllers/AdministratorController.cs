using E_Attend.Entities.Models;
using E_Attend.Service.Course;
using E_Attend.Service.Instructor;
using E_Attend.Service.Student;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using E_Attend.Entities.Repositories;
using E_Attend.Service.Attendance;
using E_Attend.Service.Enrollment;
using E_Attend.Service.Lecture;
using Microsoft.AspNetCore.Authorization;

namespace E_Attend.Presentation.Controllers;

[Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Admin")]
[ApiController]
[Route("admin")]
    
public class AdministratorController : ControllerBase {
    private readonly IInstructorService _instructorService;
    private readonly IStudentService _studentService;
    private readonly ICourseService _courseService;
    private readonly IEnrollmentService _enrollmentService;
    private readonly IAttendanceService _attendanceService;
    private readonly ILectureService _lectureService;

    public AdministratorController(IInstructorService instructorService, ICourseService courseService,
        IStudentService studentService, IEnrollmentService enrollmentService, ILectureService lectureService,
        IAttendanceService attendanceService) {
        _studentService = studentService;
        _courseService = courseService;
        _instructorService = instructorService;
        _enrollmentService = enrollmentService;
        _lectureService = lectureService;
        _attendanceService = attendanceService;
    }

    
    [HttpGet("lectures")]
    public async Task<IActionResult> ViewAllLectures() => Ok(await _lectureService.ViewAllLecturesAsync());

    [HttpGet("lectures/{lectureId}")]
    public async Task<IActionResult> GetLectureById(string lectureId) => Ok(await _lectureService.GetLectureByIdAsync(lectureId));

    [HttpGet("lectures/course/{courseId}")]
    public async Task<IActionResult> GetLecturesByCourse(string courseId) => Ok(await _lectureService.GetLecturesByCourseAsync(courseId));

    [HttpPost("lectures")]
    public async Task<IActionResult> AddLecture([FromBody] Entities.Models.Lecture lecture) => Ok(await _lectureService.AddLectureAsync(lecture));

    [HttpPut("lectures/{lectureId}")]
    public async Task<IActionResult> UpdateLecture(string lectureId, [FromBody] Entities.Models.Lecture updatedLecture) => Ok(await _lectureService.UpdateLectureAsync(lectureId, updatedLecture));

    [HttpDelete("lectures/{lectureId}")]
    public async Task<IActionResult> DeleteLecture(string lectureId) => Ok(await _lectureService.DeleteLectureAsync(lectureId));

    [HttpGet("lectures/{lectureId}/students")]
    public async Task<IActionResult> GetStudentsAttendedLecture(string lectureId) => Ok(await _lectureService.GetStudentsAttendLecture(lectureId));

    [HttpGet("lectures/student/{studentId}/course/{courseId}")]
    public async Task<IActionResult> GetStudentAttendLecture(string studentId, string courseId) => Ok(await _lectureService.GetStudentAttendLecture(studentId, courseId));


    [HttpGet("attendance/{attendanceId}")]
    public async Task<IActionResult> ViewAttendance(string attendanceId) =>
        Ok(await _attendanceService.ViewAttendanceAsync(attendanceId));

    // Courses
    [HttpGet("courses/student/{studentId}")]
    public async Task<IActionResult> ViewCoursesByStudentId(string studentId) =>
        Ok(await _courseService.ViewAllCoursesByStudentIDAsync(studentId));

    [HttpGet("courses/view-all")]
    public async Task<IActionResult> ViewAllCourses() =>
        Ok(await _courseService.ViewAllCourses());

    [HttpPost("courses/add")]
    public async Task<IActionResult> CreateCourse([FromBody] Course newCourse) =>
        Ok(await _courseService.AddCourseAsync(newCourse));

    [HttpPut("courses/{courseId}")]
    public async Task<IActionResult> UpdateCourse(string courseId, [FromBody] Course updatedCourse) =>
        Ok(await _courseService.UpdateCourseAsync(courseId, updatedCourse));

    [HttpDelete("courses/{courseId}")]
    public async Task<IActionResult> DeleteCourse(string courseId) =>
        Ok(await _courseService.DeleteCourseAsync(courseId));

    // Instructors
    [HttpGet("instructors")]
    public async Task<IActionResult> ViewAllInstructors() =>
        Ok(await _instructorService.ViewAllInstructorsAsync());

    [HttpPost("instructors")]
    public async Task<IActionResult> AddInstructor([FromBody] Instructor instructor) =>
        Ok(await _instructorService.AddInstructorAsync(instructor));

    [HttpPut("instructors/{instructorId}")]
    public async Task<IActionResult> UpdateInstructor(string instructorId, [FromBody] Instructor updatedInstructor) =>
        Ok(await _instructorService.UpdateInstructorAsync(instructorId, updatedInstructor));

    [HttpDelete("instructors/{instructorId}")]
    public async Task<IActionResult> DeleteInstructor(string instructorId) =>
        Ok(await _instructorService.DeleteInstructorAsync(instructorId));

    
    [HttpGet("students")]
    public async Task<IActionResult> ViewAllStudentsAsync() =>
        Ok(await _studentService.ViewAllStudents());
    // Students
    [HttpPost("students")]
    public async Task<IActionResult> AddStudent([FromBody] Student student) =>
        Ok(await _studentService.AddStudentAsync(student));

    [HttpPut("students/{studentId}")]
    public async Task<IActionResult> UpdateStudent(string studentId, [FromBody] Student updatedStudent) =>
        Ok(await _studentService.UpdateStudentAsync(studentId, updatedStudent));

    [HttpDelete("students/{studentId}")]
    public async Task<IActionResult> DeleteStudent(string studentId) =>
        Ok(await _studentService.DeleteStudentAsync(studentId));


    [HttpPost("enrollments")]
    public async Task<IActionResult> EnrollStudent([FromQuery] string studentId, [FromQuery] string courseId) =>
        Ok(await _enrollmentService.EnrollCourseAsync(studentId, courseId));

    [HttpPut("enrollments/{enrollmentId}")]
    public async Task<IActionResult> UpdateEnrollment(string enrollmentId, [FromBody] Enrollment updatedEnrollment) =>
        Ok(await _enrollmentService.UpdateEnrollmentAsync(enrollmentId, updatedEnrollment));

    [HttpGet("enrollments/student/{studentId}")]
    public async Task<IActionResult> ViewEnrollmentsByStudent(string studentId) =>
        Ok(await _enrollmentService.ViewAllEnrollmentsOfStudentAsync(studentId));

    [HttpDelete("enrollments/{enrollmentId}")]
    public async Task<IActionResult> DeleteEnrollment(string enrollmentId) =>
        Ok(await _enrollmentService.DeleteEnrollmentAsync(enrollmentId));
}