namespace E_Attend.Service.Enrollment
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollCourseAsync(int studentId, int courseId);
        Task<bool> UpdateEnrollmentAsync(int enrollmentId, Entities.Models.Enrollment updatedEnrollment);
        Task<IEnumerable<Entities.Models.Enrollment>> ViewAllEnrollmentsOfStudentAsync(int studentId);
        Task<bool> DeleteEnrollmentAsync(int enrollmentId);

    }
}
