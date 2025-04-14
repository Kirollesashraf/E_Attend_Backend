using E_Attend.Entities.Models;
using E_Attend.Service.Course;
using E_Attend.Service.Instructor;
using E_Attend.Service.Student;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using E_Attend.Service.Enrollment;

namespace E_Attend.Presentation.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IEnrollmentService _enrollmentService;

        public AdministratorController(IInstructorService instructorService, ICourseService courseService, IStudentService studentService, IEnrollmentService enrollmentService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _instructorService = instructorService;
            _enrollmentService = enrollmentService;
        }

        // Courses
        [HttpGet("courses/student/{studentId}")]
        public async Task<IActionResult> ViewCoursesByStudentId(int studentId) =>
            Ok(await _courseService.ViewAllCoursesByStudentIDAsync(studentId));

        [HttpPost("courses/add")]
        public async Task<IActionResult> CreateCourse([FromBody] Course newCourse) =>
            Ok(await _courseService.AddCourseAsync(newCourse));

        [HttpPut("courses/{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] Course updatedCourse) =>
            Ok(await _courseService.UpdateCourseAsync(courseId, updatedCourse));

        [HttpDelete("courses/{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId) =>
            Ok(await _courseService.DeleteCourseAsync(courseId));

        // Instructors
        [HttpGet("instructors")]
        public async Task<IActionResult> ViewAllInstructors() =>
            Ok(await _instructorService.ViewAllInstructorsAsync());

        [HttpPost("instructors")]
        public async Task<IActionResult> AddInstructor([FromBody] Instructor instructor) =>
            Ok(await _instructorService.AddInstructorAsync(instructor));

        [HttpPut("instructors/{instructorId}")]
        public async Task<IActionResult> UpdateInstructor(int instructorId, [FromBody] Instructor updatedInstructor) =>
            Ok(await _instructorService.UpdateInstructorAsync(instructorId, updatedInstructor));

        [HttpDelete("instructors/{instructorId}")]
        public async Task<IActionResult> DeleteInstructor(int instructorId) =>
            Ok(await _instructorService.DeleteInstructorAsync(instructorId));

        // Students
        [HttpPost("students")]
        public async Task<IActionResult> AddStudent([FromBody] Student student) =>
            Ok(await _studentService.AddStudentAsync(student));

        [HttpPut("students/{studentId}")]
        public async Task<IActionResult> UpdateStudent(int studentId, [FromBody] Student updatedStudent) =>
            Ok(await _studentService.UpdateStudentAsync(studentId, updatedStudent));

        [HttpDelete("students/{studentId}")]
        public async Task<IActionResult> DeleteStudent(int studentId) =>
            Ok(await _studentService.DeleteStudentAsync(studentId));
        
        
        [HttpPost("enrollments")]
        public async Task<IActionResult> EnrollStudent([FromQuery] int studentId, [FromQuery] int courseId) =>
            Ok(await _enrollmentService.EnrollCourseAsync(studentId, courseId));

        [HttpPut("enrollments/{enrollmentId}")]
        public async Task<IActionResult> UpdateEnrollment(int enrollmentId, [FromBody] Enrollment updatedEnrollment) =>
            Ok(await _enrollmentService.UpdateEnrollmentAsync(enrollmentId, updatedEnrollment));

        [HttpGet("enrollments/student/{studentId}")]
        public async Task<IActionResult> ViewEnrollmentsByStudent(int studentId) =>
            Ok(await _enrollmentService.ViewAllEnrollmentsOfStudentAsync(studentId));

        [HttpDelete("enrollments/{enrollmentId}")]
        public async Task<IActionResult> DeleteEnrollment(int enrollmentId) =>
            Ok(await _enrollmentService.DeleteEnrollmentAsync(enrollmentId));
        
    }
}
