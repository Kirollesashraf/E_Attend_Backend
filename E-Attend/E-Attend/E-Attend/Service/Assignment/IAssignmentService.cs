
using E_Attend.Entities.DTOs;

namespace E_Attend.Service.Assignment.Interfaces;

public interface IAssignmentService {
    public Task<Task> UpdateTitleAsync(int assignmentId, string newTitle);
    public Task<Task> UpdateDescriptionAsync(int assignmentId, string newDescription);
    public Task<Task> UpdateDueDateAsync(int assignmentId, DateTime newDate);
    public Task<Task> DeleteAssignmentAsync(int assignmentId);
    public Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignment);
    public Task<Entities.Models.Assignment> ViewAssignmentAsync(int assignmentId);

    public Task<IEnumerable<Entities.Models.Assignment>> ViewAllAssignmentsByInstructorIdAsync(int instructorId);

}