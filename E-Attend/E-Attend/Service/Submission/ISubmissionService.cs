using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Submission
{
    public interface ISubmissionService
    {
        Task<GeneralResponse<Entities.Models.Submission>> AddSubmissionAsync(Entities.Models.Submission submission);
        Task<GeneralResponse<object>> UpdateSubmissionAsync(string submissionId, Entities.Models.Submission updatedSubmission);
        Task<GeneralResponse<IEnumerable<Entities.Models.Submission>>> ViewAllSubmissionsOfStudentAsync(string studentId);
        Task<GeneralResponse<object>> DeleteSubmissionAsync(string submissionId);
    }
}