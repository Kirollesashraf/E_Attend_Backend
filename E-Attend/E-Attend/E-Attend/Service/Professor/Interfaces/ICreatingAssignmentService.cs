using E_Attend.Entities.DTOs;

namespace E_Attend.Service.Assignment;

public interface ICreatingAssignmentService {
    public Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignment);
}