// IAssignmentService.cs (Interface)
using E_Attend.Entities.DTOs;

namespace E_Attend.Service.Assignment.Interfaces;

public interface IAssignmentService
{
    Task<GeneralResponse<Entities.Models.Assignment>> ViewAssignmentAsync(string assignmentId);
    Task<GeneralResponse<IEnumerable<Entities.Models.Assignment>>> ViewAllAssignmentsByInstructorIdAsync(string instructorId);
    Task<GeneralResponse<Entities.Models.Assignment>> CreateAssignmentAsync(Entities.Models.Assignment assignment);
    Task<GeneralResponse<object>> DeleteAssignmentAsync(string assignmentId);
    Task<GeneralResponse<object>> UpdateAssignment(string assignmentId, Entities.Models.Assignment newAssignment);
}