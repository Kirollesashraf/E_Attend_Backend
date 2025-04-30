using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Course;

public class CourseService : ICourseService {
    private readonly IUnitOfWork unitOfWork;

    public CourseService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<Entities.Models.Course>> AddCourseAsync(Entities.Models.Course course) {
        await unitOfWork.CourseRepository.AddAsync(course);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<Entities.Models.Course>.Success(course, "Course added successfully");
    }

    public async Task<GeneralResponse<object>> UpdateCourseAsync(int courseId, Entities.Models.Course updatedCourse) {
        var course = await unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.ID == courseId);
        if (course == null)
            return GeneralResponse<object>.Error("Course not found.");

        course.InstructorID = updatedCourse.InstructorID;
        course.CreatedAt = updatedCourse.CreatedAt;
        course.Code = updatedCourse.Code;
        course.Name = updatedCourse.Name;
        course.CreditHours = updatedCourse.CreditHours;

        await unitOfWork.CourseRepository.UpdateAsync(course);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Course updated successfully");
    }

    public async Task<GeneralResponse<IEnumerable<Entities.Models.Course>>> ViewAllCoursesByStudentIDAsync(
        int studentId) {
        var enrollments = await unitOfWork.EnrollmentRepository
            .GetAllAsync(e => e.StudentID == studentId);

        var courseIds = enrollments.Select(e => e.CourseID).Distinct();

        var courses = await unitOfWork.CourseRepository
            .GetAllAsync(c => courseIds.Contains(c.ID));

        return GeneralResponse<IEnumerable<Entities.Models.Course>>.Success(courses);
    }

    public async Task<IEnumerable<Entities.Models.Course>> ViewAllCourses() {
        return await unitOfWork.CourseRepository.GetAllAsync();
    }

    public async Task<GeneralResponse<object>> DeleteCourseAsync(int courseId) {
        var course = await unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.ID == courseId);
        if (course == null)
            return GeneralResponse<object>.Error("Course not found.");

        await unitOfWork.CourseRepository.RemoveAsync(course);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Course deleted successfully");
    }

    public async Task<GeneralResponse<byte[]>> DownloadCourseAsync(int courseId) {
        // Implement your download logic here.  For now, returning an error:
        return GeneralResponse<byte[]>.Error("Download not implemented");
    }
}