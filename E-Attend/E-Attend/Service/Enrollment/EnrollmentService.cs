using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Enrollment;


public class EnrollmentService : IEnrollmentService {
    private readonly IUnitOfWork unitOfWork;

    public EnrollmentService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> EnrollCourseAsync(int studentId, int courseId) {
        await unitOfWork.EnrollmentRepository.AddAsync(new Entities.Models.Enrollment { StudentID = studentId, CourseID = courseId, EnrolledAt = DateTime.UtcNow });
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> UpdateEnrollmentAsync(int enrollmentId, Entities.Models.Enrollment updatedEnrollment) {
        var enrollment = await unitOfWork.EnrollmentRepository.GetFirstOrDefaultAsync(e => e.ID == enrollmentId);
        if (enrollment == null) throw new KeyNotFoundException("Enrollment not found.");

        enrollment.CourseID = updatedEnrollment.CourseID;
        enrollment.StudentID = updatedEnrollment.StudentID;
        enrollment.EnrolledAt = updatedEnrollment.EnrolledAt;

        await unitOfWork.EnrollmentRepository.UpdateAsync(enrollment);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<IEnumerable<Entities.Models.Enrollment>> ViewAllEnrollmentsOfStudentAsync(int studentId) {
        return await unitOfWork.EnrollmentRepository.GetAllAsync(e => e.StudentID == studentId);
    }

    public async Task<bool> DeleteEnrollmentAsync(int enrollmentId) {
        var enrollment = await unitOfWork.EnrollmentRepository.GetFirstOrDefaultAsync(e => e.ID == enrollmentId);
        if (enrollment == null) throw new KeyNotFoundException("Enrollment not found.");

        await unitOfWork.EnrollmentRepository.RemoveAsync(enrollment);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
