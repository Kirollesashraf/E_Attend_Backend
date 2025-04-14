using E_Attend.Service.Course;
using E_Attend.Service.Sheet;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;


public class StudentController : ControllerBase {
    private readonly ISheetService _sheetService; 
    private readonly ICourseService _courseService; 
    
    public StudentController(ICourseService courseService  ,  ISheetService sheetService) {
        _sheetService = sheetService;
        _courseService = courseService;

    }
    
    [HttpPost("sheets/{sheetId}/upload")]
    public async Task<IActionResult> UploadSheet(int sheetId, [FromBody] byte[] fileData) =>
        Ok(await _sheetService.UploadSheetAsync(sheetId, fileData));
    
    [HttpGet("courses/student/{studentId}")]
    public async Task<IActionResult> ViewCoursesByStudentId(int studentId) =>
        Ok(await _courseService.ViewAllCoursesByStudentIDAsync(studentId));
}