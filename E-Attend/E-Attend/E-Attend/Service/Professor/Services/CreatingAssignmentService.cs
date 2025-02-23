
using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Assignment;

using Entities.Models;

public class CreatingAssignmentService:ICreatingAssignmentService {
    
    private readonly IUnitOfWork unitOfWork;

    public CreatingAssignmentService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork; 
    }
    public async Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignment) {
        if (string.IsNullOrWhiteSpace(assignment.Title) || string.IsNullOrWhiteSpace(assignment.Description))
            throw new ArgumentException("Title and description are required.");
        

        await unitOfWork.AssignmentRepository.AddAsync(new Assignment() {
            CourseID = assignment.CourseID,
            CreatedAt = assignment.CreatedAt,
            Description = assignment.Description,
            Title = assignment.Title,
            DueDate = assignment.DueDate
            
            
        });
        await unitOfWork.CompleteAsync();

        return assignment;
    }
    
}