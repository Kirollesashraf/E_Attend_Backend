using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Service.Assignment.Interfaces;
using Microsoft.AspNetCore.Mvc; // For IActionResult

namespace E_Attend.Service.Assignment;

using Entities.Models;

public class AssignmentService : IAssignmentService
{
    private readonly IUnitOfWork unitOfWork;

    public AssignmentService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<Assignment>> ViewAssignmentAsync(string assignmentId)
    {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        return assignment == null
            ? GeneralResponse<Assignment>.Error("Assignment not found")
            : GeneralResponse<Assignment>.Success(assignment);
    }

    public async Task<GeneralResponse<IEnumerable<Assignment>>> ViewAllAssignmentsByInstructorIdAsync(string instructorId)
    {
        var assignments =
            from course in await unitOfWork.CourseRepository.GetAllAsync(c => c.InstructorID == instructorId)
            join assignment in await unitOfWork.AssignmentRepository.GetAllAsync()
                on course.ID equals assignment.CourseID
            select assignment;

        return GeneralResponse<IEnumerable<Assignment>>.Success(assignments);
    }

    public async Task<GeneralResponse<Assignment>> CreateAssignmentAsync(Assignment assignment)
    {
        if (string.IsNullOrWhiteSpace(assignment.Title) || string.IsNullOrWhiteSpace(assignment.Description))
            return GeneralResponse<Assignment>.Error("Title and description are required.");


        var newAssignment = new Assignment
        {
            CourseID = assignment.CourseID,
            CreatedAt = assignment.CreatedAt,
            Description = assignment.Description,
            Title = assignment.Title,
            DueDate = assignment.DueDate
        };

        await unitOfWork.AssignmentRepository.AddAsync(newAssignment);
        await unitOfWork.CompleteAsync();

        return GeneralResponse<Assignment>.Success(newAssignment); // Return the DTO
    }

    public async Task<GeneralResponse<object>> DeleteAssignmentAsync(string assignmentId)
    {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null)
            return GeneralResponse<object>.Error("Assignment not found.");

        await unitOfWork.AssignmentRepository.RemoveAsync(assignment);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Assignment deleted successfully");
    }

    public async Task<GeneralResponse<object>> UpdateAssignment(string assignmentId, Assignment newAssignment)
    {
        var assignment = await unitOfWork.AssignmentRepository.GetFirstOrDefaultAsync(a => a.ID == assignmentId);
        if (assignment == null)
            return GeneralResponse<object>.Error("Assignment not found.");

        assignment.DueDate = newAssignment.DueDate;
        assignment.Description = newAssignment.Description;
        assignment.CreatedAt = newAssignment.CreatedAt;
        assignment.CourseID = newAssignment.CourseID;
        assignment.Title = newAssignment.Title;

        await unitOfWork.AssignmentRepository.UpdateAsync(assignment);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Assignment updated successfully");
    }
}
