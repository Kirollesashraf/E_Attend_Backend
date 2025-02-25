namespace E_Attend.Service.Submission
{
    public interface ISubmissionService
    {
        Task<bool> AddSubmissionAsync(Submission submission);
        Task<bool> UpdateSubmissionAsync(int submissionId, Submission updatedSubmission);
        Task<IEnumerable<Submission>> ViewAllSubmissionsOfStudentAsync(int studentId);
        Task<bool> DeleteSubmissionAsync(int submissionId);
    }
}
