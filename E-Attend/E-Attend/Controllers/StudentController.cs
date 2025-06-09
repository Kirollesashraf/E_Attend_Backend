using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service._Student;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService) => _studentService = studentService;

    [HttpGet]
    public async Task<IActionResult> GetStudentsAsync() =>
        Ok(await _studentService.GetStudentsAsync());

    [HttpPut("{studentId}")]
    public async Task<IActionResult> UpdateStudentAsync(string studentId, [FromBody] UpdateStudentDto updatedStudent) =>
        Ok(await _studentService.UpdateStudentAsync(studentId, updatedStudent));

    [HttpDelete("{studentId}")]
    public async Task<IActionResult> DeleteStudentAsync(string studentId) =>
        Ok(await _studentService.DeleteStudentAsync(studentId));
}