using E_Attend.Entities;
using E_Attend.Service._Attendance;
using E_Attend.Service._Student;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("students")]
    public async Task<IActionResult> GetStudentsAsync()
        => Ok(await _service.GetStudentsAsync());
}