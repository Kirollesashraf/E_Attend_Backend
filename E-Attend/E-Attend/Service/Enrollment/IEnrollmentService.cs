using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Enrollment
{
    public interface IEnrollmentService
    {
        Task<GeneralResponse<Entities.Models.Enrollment>> EnrollCourseAsync(string studentId, string courseId);
        Task<GeneralResponse<object>> UpdateEnrollmentAsync(string enrollmentId, Entities.Models.Enrollment updatedEnrollment);
        Task<GeneralResponse<IEnumerable<Entities.Models.Enrollment>>> ViewAllEnrollmentsOfStudentAsync(string studentId);
        Task<GeneralResponse<object>> DeleteEnrollmentAsync(string enrollmentId);
    }
}