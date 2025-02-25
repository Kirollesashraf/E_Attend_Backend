using E_Attend.Entities.Models;
using E_Attend.Service.Student;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Presentation.Controllers;

[Route("/student")]
[ApiController]
public class StudentController : ControllerBase {
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService) {
        this._studentService = studentService;
    }

    [HttpPost("/add-student")]
    public async Task<IActionResult> Add([FromBody] Student student) =>
        Ok(await _studentService.AddStudentAsync(student));

    [HttpPost("/update-student/{studentId}")]
    public async Task<IActionResult> Update(int studentId, [FromBody] Student updatedStudent) =>
        Ok(await _studentService.UpdateStudentAsync(studentId, updatedStudent));

    // [HttpPost("/view-by-section-id/{sectionId}")]
    // public async Task<OkObjectResult> ViewBySectionId(int sectionId) =>
    //     Ok(await _studentService.ViewAllStudentsOfSectionAsync(sectionId));

    [HttpPost("/delete-student/{studentId}")]
    public async Task<IActionResult> Delete(int studentId) =>
        Ok(await _studentService.DeleteStudentAsync(studentId));
}