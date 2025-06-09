using E_Attend.Service._Instructor;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("[controller]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _service;

    public InstructorController(IInstructorService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("instructors")]
    public async Task<IActionResult> GetInstructorsAsync()
        => Ok(await _service.GetAllInstructorAsync());
}