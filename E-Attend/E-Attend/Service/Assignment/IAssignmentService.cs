
using E_Attend.Entities.DTOs;

namespace E_Attend.Service.Assignment.Interfaces;

public interface IAssignmentService {
    public Task<Task> UpdateAssignment(int assignmentId, AssignmentDTO newAssignment);

    public Task<Task> DeleteAssignmentAsync(int assignmentId);
    public Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignment);
    public Task<Entities.Models.Assignment> ViewAssignmentAsync(int assignmentId);

    public Task<IEnumerable<Entities.Models.Assignment>> ViewAllAssignmentsByInstructorIdAsync(int instructorId);

}