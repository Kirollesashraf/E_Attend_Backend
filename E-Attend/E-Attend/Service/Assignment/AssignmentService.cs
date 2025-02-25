
using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Service.Assignment.Interfaces;

namespace E_Attend.Service.Assignment;

using Entities.Models;

public class AssignmentService : IAssignmentService {
    
    private readonly IUnitOfWork unitOfWork;

    public AssignmentService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork; 
    }

    public async Task<Assignment> ViewAssignmentAsync(int assignmentId) {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null) throw new KeyNotFoundException("Assignment not found.");
        return assignment;
    }

    public async Task<IEnumerable<Assignment>> ViewAllAssignmentsByInstructorIdAsync(int instructorId)
    {
        var assignments = 
            from course in await unitOfWork.CourseRepository.GetAllAsync(c => c.InstructorID == instructorId)
            join assignment in await unitOfWork.AssignmentRepository.GetAllAsync(a => true) 
            on course.ID equals assignment.CourseID
            select assignment;

        return assignments;
    }

    public async Task<AssignmentDTO> CreateAssignmentAsync(AssignmentDTO assignment) {
        if (string.IsNullOrWhiteSpace(assignment.Title) || string.IsNullOrWhiteSpace(assignment.Description))
            throw new ArgumentException("Title and description are required.");
        

        await unitOfWork.AssignmentRepository.AddAsync(new Assignment {
            CourseID = assignment.CourseID,
            CreatedAt = assignment.CreatedAt,
            Description = assignment.Description,
            Title = assignment.Title,
            DueDate = assignment.DueDate
            
            
        });
        await unitOfWork.CompleteAsync();

        return assignment;
    }
    
    public async Task<Task> DeleteAssignmentAsync(int assignmentId) {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null) throw new KeyNotFoundException("Assignment not found.");
        await unitOfWork.AssignmentRepository.RemoveAsync(assignment);
        await unitOfWork.CompleteAsync();
        return Task.CompletedTask;
    }

    public async Task<Task> UpdateAssignment(int assignmentId, AssignmentDTO newAssignment) {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null) throw new KeyNotFoundException("Assignment not found.");

        assignment.DueDate = newAssignment.DueDate;
        assignment.Description = newAssignment.Description;
        assignment.CreatedAt = newAssignment.CreatedAt;
        assignment.CourseID = newAssignment.CourseID;
        assignment.Title = newAssignment.Title;
        
        await unitOfWork.AssignmentRepository.UpdateAsync(assignment);
        await unitOfWork.CompleteAsync();
        return Task.CompletedTask;

    }

  
    
    
}