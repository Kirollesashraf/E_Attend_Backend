using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using E_Attend.Service.Assignment;
using Microsoft.AspNetCore.Mvc;

namespace E_Attend.Controllers;

[Route("/assignment")]
[ApiController]
public class ProfessorController :  ControllerBase {
    private readonly ICreatingAssignmentService _creatingAssignmentService ;

    public ProfessorController(ICreatingAssignmentService  creatingAssignmentService) {
        this._creatingAssignmentService = creatingAssignmentService;
    }
    
    [HttpPost("/create")]
    public async Task<IActionResult> CreateAssignment([FromBody] AssignmentDTO assignment) =>
        Ok(await _creatingAssignmentService.CreateAssignmentAsync(assignment));
    
}