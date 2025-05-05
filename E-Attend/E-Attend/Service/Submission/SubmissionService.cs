using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Submission;

public class SubmissionService : ISubmissionService
{
    private readonly IUnitOfWork unitOfWork;

    public SubmissionService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<Entities.Models.Submission>> AddSubmissionAsync(Entities.Models.Submission submission)
    {
        await unitOfWork.SubmissionRepository.AddAsync(submission);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<Entities.Models.Submission>.Success(submission, "Submission added successfully.");
    }

    public async Task<GeneralResponse<object>> UpdateSubmissionAsync(string submissionId, Entities.Models.Submission updatedSubmission)
    {
        var submission = await unitOfWork.SubmissionRepository.GetFirstOrDefaultAsync(s => s.ID == submissionId);
        if (submission == null)
            return GeneralResponse<object>.Error("Submission not found.");

        submission.FilePath = updatedSubmission.FilePath;
        submission.Grade = updatedSubmission.Grade;
        submission.SubmittedAt = updatedSubmission.SubmittedAt;

        await unitOfWork.SubmissionRepository.UpdateAsync(submission);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Submission updated successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Entities.Models.Submission>>> ViewAllSubmissionsOfStudentAsync(string studentId)
    {
        var submissions = await unitOfWork.SubmissionRepository.GetAllAsync(s => s.StudentID == studentId);
        return GeneralResponse<IEnumerable<Entities.Models.Submission>>.Success(submissions);
    }

    public async Task<GeneralResponse<object>> DeleteSubmissionAsync(string submissionId)
    {
        var submission = await unitOfWork.SubmissionRepository.GetFirstOrDefaultAsync(s => s.ID == submissionId);
        if (submission == null)
            return GeneralResponse<object>.Error("Submission not found.");

        await unitOfWork.SubmissionRepository.RemoveAsync(submission);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Submission deleted successfully.");
    }
}