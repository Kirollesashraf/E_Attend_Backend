using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service._Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService) => _studentService = studentService;


    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetStudentsAsync() =>
        Ok(await _studentService.GetStudentsAsync());


    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student")]
    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudentAsync(string studentId) =>
        Ok(await _studentService.GetStudentAsync(studentId));
    
    
    
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student")]
    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudentByUserIdAsync(string studentId) =>
        Ok(await _studentService.GetStudentByUserIdAsync(studentId));


    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [HttpPut("{studentId}")]
    public async Task<IActionResult> UpdateStudentAsync(string studentId, [FromBody] UpdateStudentDto updatedStudent) =>
        Ok(await _studentService.UpdateStudentAsync(studentId, updatedStudent));

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [HttpDelete("{studentId}")]
    public async Task<IActionResult> DeleteStudentAsync(string studentId) =>
        Ok(await _studentService.DeleteStudentAsync(studentId));
}