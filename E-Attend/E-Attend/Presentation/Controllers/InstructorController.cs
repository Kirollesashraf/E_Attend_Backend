using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using E_Attend.Service.Assignment.Interfaces;
using E_Attend.Service.Attendance;
using E_Attend.Service.Sheet;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("instructor")]
[ApiController]
public class InstructorController : ControllerBase {
        private readonly ISheetService _sheetService;
        private readonly IAssignmentService _assignmentService;
        private readonly IAttendanceService _attendanceService;


        public InstructorController(ISheetService sheetService, IAssignmentService assignmentService, IAttendanceService attendanceService) {
            _sheetService = sheetService;
            _assignmentService = assignmentService;
            _attendanceService = attendanceService;
        }
        
        
        
        [HttpGet("attendance/{attendanceId}")]
        public async Task<IActionResult> ViewAttendance(int attendanceId) =>
            Ok(await _attendanceService.ViewAttendanceAsync(attendanceId));
        [HttpPost("sheets")]
        public async Task<IActionResult> AddSheet([FromBody] Sheet sheet) =>
            Ok(await _sheetService.AddSheetAsync(sheet));

        [HttpPut("sheets/{sheetId}")]
        public async Task<IActionResult> UpdateSheet(int sheetId, [FromBody] Sheet updatedSheet) =>
            Ok(await _sheetService.UpdateSheetAsync(sheetId, updatedSheet));

        [HttpGet("sheets/{sheetId}")]
        public async Task<IActionResult> ViewSheet(int sheetId) =>
            Ok(await _sheetService.ViewSheetAsync(sheetId));

        [HttpDelete("sheets/{sheetId}")]
        public async Task<IActionResult> DeleteSheet(int sheetId) =>
            Ok(await _sheetService.DeleteSheetAsync(sheetId));

        
        [HttpPost("assignments")]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment) =>
            Ok(await _assignmentService.CreateAssignmentAsync(assignment));

        [HttpPut("assignments/{assignmentId}")]
        public async Task<IActionResult> UpdateAssignment(int assignmentId, [FromBody] Assignment newAssignment) =>
            Ok(await _assignmentService.UpdateAssignment(assignmentId, newAssignment));

        [HttpDelete("assignments/{assignmentId}")]
        public async Task<IActionResult> DeleteAssignment(int assignmentId) =>
            Ok(await _assignmentService.DeleteAssignmentAsync(assignmentId));

        [HttpGet("assignments/{assignmentId}")]
        public async Task<IActionResult> ViewAssignment(int assignmentId) =>
            Ok(await _assignmentService.ViewAssignmentAsync(assignmentId));

        [HttpGet("assignments/instructor/{instructorId}")]
        public async Task<IActionResult> ViewAllAssignmentsByInstructor(int instructorId) =>
            Ok(await _assignmentService.ViewAllAssignmentsByInstructorIdAsync(instructorId));

}