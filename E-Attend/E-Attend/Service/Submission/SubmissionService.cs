using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Submission;

public class SubmissionService : ISubmissionService {
    private readonly IUnitOfWork unitOfWork;

    public SubmissionService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> AddSubmissionAsync(Entities.Models.Submission submission) {
        await unitOfWork.SubmissionRepository.AddAsync(submission);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> UpdateSubmissionAsync(int submissionId, Entities.Models.Submission updatedSubmission) {
        var submission = await unitOfWork.SubmissionRepository.GetFirstOrDefaultAsync(s => s.ID == submissionId);
        if (submission == null) throw new KeyNotFoundException("Submission not found.");

        submission.FilePath = updatedSubmission.FilePath;
        submission.Grade = updatedSubmission.Grade;
        submission.SubmittedAt = updatedSubmission.SubmittedAt;

        await unitOfWork.SubmissionRepository.UpdateAsync(submission);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<IEnumerable<Entities.Models.Submission>> ViewAllSubmissionsOfStudentAsync(int studentId) {
        return await unitOfWork.SubmissionRepository.GetAllAsync(s => s.StudentID == studentId);
    }

    public async Task<bool> DeleteSubmissionAsync(int submissionId) {
        var submission = await unitOfWork.SubmissionRepository.GetFirstOrDefaultAsync(s => s.ID == submissionId);
        if (submission == null) throw new KeyNotFoundException("Submission not found.");

        await unitOfWork.SubmissionRepository.RemoveAsync(submission);
        await unitOfWork.CompleteAsync();
        return true;
    }
}