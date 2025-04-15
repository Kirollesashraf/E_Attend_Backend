using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Enrollment;

public class EnrollmentService : IEnrollmentService
{
    private readonly IUnitOfWork unitOfWork;

    public EnrollmentService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<Entities.Models.Enrollment>> EnrollCourseAsync(int studentId, int courseId)
    {
        var enrollment = new Entities.Models.Enrollment { StudentID = studentId, CourseID = courseId, EnrolledAt = DateTime.UtcNow };
        await unitOfWork.EnrollmentRepository.AddAsync(enrollment);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<Entities.Models.Enrollment>.Success(enrollment, "Student enrolled successfully.");
    }

    public async Task<GeneralResponse<object>> UpdateEnrollmentAsync(int enrollmentId, Entities.Models.Enrollment updatedEnrollment)
    {
        var enrollment = await unitOfWork.EnrollmentRepository.GetFirstOrDefaultAsync(e => e.ID == enrollmentId);
        if (enrollment == null)
            return GeneralResponse<object>.Error("Enrollment not found.");

        enrollment.CourseID = updatedEnrollment.CourseID;
        enrollment.StudentID = updatedEnrollment.StudentID;
        enrollment.EnrolledAt = updatedEnrollment.EnrolledAt;

        await unitOfWork.EnrollmentRepository.UpdateAsync(enrollment);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Enrollment updated successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Entities.Models.Enrollment>>> ViewAllEnrollmentsOfStudentAsync(int studentId)
    {
        var enrollments = await unitOfWork.EnrollmentRepository.GetAllAsync(e => e.StudentID == studentId);
        return GeneralResponse<IEnumerable<Entities.Models.Enrollment>>.Success(enrollments);
    }

    public async Task<GeneralResponse<object>> DeleteEnrollmentAsync(int enrollmentId)
    {
        var enrollment = await unitOfWork.EnrollmentRepository.GetFirstOrDefaultAsync(e => e.ID == enrollmentId);
        if (enrollment == null)
            return GeneralResponse<object>.Error("Enrollment not found.");

        await unitOfWork.EnrollmentRepository.RemoveAsync(enrollment);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Enrollment deleted successfully.");
    }
}