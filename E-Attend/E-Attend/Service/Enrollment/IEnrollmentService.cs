namespace E_Attend.Service.Enrollment
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollCourseAsync(int studentId, int courseId);
        Task<bool> UpdateEnrollmentAsync(int enrollmentId, Enrollment updatedEnrollment);
        Task<IEnumerable<Enrollment>> ViewAllEnrollmentsOfStudentAsync(int studentId);
        Task<bool> DeleteEnrollmentAsync(int enrollmentId);

    }
}
