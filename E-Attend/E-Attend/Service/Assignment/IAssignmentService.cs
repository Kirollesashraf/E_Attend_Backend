// IAssignmentService.cs (Interface)
using E_Attend.Entities.DTOs;

namespace E_Attend.Service.Assignment.Interfaces;

public interface IAssignmentService
{
    Task<GeneralResponse<Entities.Models.Assignment>> ViewAssignmentAsync(int assignmentId);
    Task<GeneralResponse<IEnumerable<Entities.Models.Assignment>>> ViewAllAssignmentsByInstructorIdAsync(int instructorId);
    Task<GeneralResponse<Entities.Models.Assignment>> CreateAssignmentAsync(Entities.Models.Assignment assignment);
    Task<GeneralResponse<object>> DeleteAssignmentAsync(int assignmentId);
    Task<GeneralResponse<object>> UpdateAssignment(int assignmentId, Entities.Models.Assignment newAssignment);
}