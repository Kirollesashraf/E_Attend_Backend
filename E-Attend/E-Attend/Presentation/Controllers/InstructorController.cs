using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using E_Attend.Service.Assignment.Interfaces;
using E_Attend.Service.Attendance;
using E_Attend.Service.Lecture;
using E_Attend.Service.Sheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Authorize(AuthenticationSchemes = "Bearer" ,Roles = "Instructor")]

[Route("instructor")]
[ApiController]
public class InstructorController : ControllerBase {
        private readonly ISheetService _sheetService;
        private readonly IAssignmentService _assignmentService;
        private readonly IAttendanceService _attendanceService;
        private readonly ILectureService _lectureService;


        public InstructorController(ISheetService sheetService, ILectureService lectureService, IAssignmentService assignmentService, IAttendanceService attendanceService) {
            _sheetService = sheetService;
            _assignmentService = assignmentService;
            _attendanceService = attendanceService;
            _lectureService = lectureService;
        }
        
        
        

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
        
        
        [HttpGet("attendance/{attendanceId}")]
        public async Task<IActionResult> ViewAttendance(string attendanceId) =>
            Ok(await _attendanceService.ViewAttendanceAsync(attendanceId));
        [HttpPost("sheets")]
        public async Task<IActionResult> AddSheet([FromBody] Sheet sheet) =>
            Ok(await _sheetService.AddSheetAsync(sheet));

        [HttpPut("sheets/{sheetId}")]
        public async Task<IActionResult> UpdateSheet(string sheetId, [FromBody] Sheet updatedSheet) =>
            Ok(await _sheetService.UpdateSheetAsync(sheetId, updatedSheet));

        [HttpGet("sheets/{sheetId}")]
        public async Task<IActionResult> ViewSheet(string sheetId) =>
            Ok(await _sheetService.ViewSheetAsync(sheetId));

        [HttpDelete("sheets/{sheetId}")]
        public async Task<IActionResult> DeleteSheet(string sheetId) =>
            Ok(await _sheetService.DeleteSheetAsync(sheetId));

        
        [HttpPost("assignments")]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment) =>
            Ok(await _assignmentService.CreateAssignmentAsync(assignment));

        [HttpPut("assignments/{assignmentId}")]
        public async Task<IActionResult> UpdateAssignment(string assignmentId, [FromBody] Assignment newAssignment) =>
            Ok(await _assignmentService.UpdateAssignment(assignmentId, newAssignment));

        [HttpDelete("assignments/{assignmentId}")]
        public async Task<IActionResult> DeleteAssignment(string assignmentId) =>
            Ok(await _assignmentService.DeleteAssignmentAsync(assignmentId));

        [HttpGet("assignments/{assignmentId}")]
        public async Task<IActionResult> ViewAssignment(string assignmentId) =>
            Ok(await _assignmentService.ViewAssignmentAsync(assignmentId));

        [HttpGet("assignments/instructor/{instructorId}")]
        public async Task<IActionResult> ViewAllAssignmentsByInstructor(string instructorId) =>
            Ok(await _assignmentService.ViewAllAssignmentsByInstructorIdAsync(instructorId));

}