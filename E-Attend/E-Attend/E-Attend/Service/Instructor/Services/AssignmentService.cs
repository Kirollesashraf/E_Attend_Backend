﻿
using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Assignment;

using Entities.Models;

public class AssignmentService {
    
    private readonly IUnitOfWork unitOfWork;

    public AssignmentService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork; 
    }

    public async Task<Assignment> ViewAssignmentAsync(int assignmentId) {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null) throw new KeyNotFoundException("Assignment not found.");
        return assignment;
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

    public async Task<Task> UpdateDueDateAsync(int assignmentId, DateTime newDate) {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null) throw new KeyNotFoundException("Assignment not found.");

        assignment.DueDate = newDate;
        await unitOfWork.AssignmentRepository.UpdateAsync(assignment);
        await unitOfWork.CompleteAsync();
        return Task.CompletedTask;

    }

    public async Task<Task> UpdateDescriptionAsync(int assignmentId, string newDescription) {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null) throw new KeyNotFoundException("Assignment not found.");

        assignment.Description = newDescription;
        await unitOfWork.AssignmentRepository.UpdateAsync(assignment);
        await unitOfWork.CompleteAsync();
        return Task.CompletedTask;

    }

    public async Task<Task> UpdateTitleAsync(int assignmentId, string newTitle) {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null) throw new KeyNotFoundException("Assignment not found.");

        assignment.Title = newTitle;
        await unitOfWork.AssignmentRepository.UpdateAsync(assignment);
        await unitOfWork.CompleteAsync();
        return Task.CompletedTask;

    }
    
    
}