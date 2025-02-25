namespace E_Attend.Service.Submission
{
    public interface ISubmissionService
    {
        Task<bool> AddSubmissionAsync(Entities.Models.Submission submission);
        Task<bool> UpdateSubmissionAsync(int submissionId, Entities.Models.Submission updatedSubmission);
        Task<IEnumerable<Entities.Models.Submission>> ViewAllSubmissionsOfStudentAsync(int studentId);
        Task<bool> DeleteSubmissionAsync(int submissionId);
    }
}
