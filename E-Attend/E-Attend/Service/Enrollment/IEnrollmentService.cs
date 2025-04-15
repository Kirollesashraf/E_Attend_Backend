using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Enrollment
{
    public interface IEnrollmentService
    {
        Task<GeneralResponse<Entities.Models.Enrollment>> EnrollCourseAsync(int studentId, int courseId);
        Task<GeneralResponse<object>> UpdateEnrollmentAsync(int enrollmentId, Entities.Models.Enrollment updatedEnrollment);
        Task<GeneralResponse<IEnumerable<Entities.Models.Enrollment>>> ViewAllEnrollmentsOfStudentAsync(int studentId);
        Task<GeneralResponse<object>> DeleteEnrollmentAsync(int enrollmentId);
    }
}