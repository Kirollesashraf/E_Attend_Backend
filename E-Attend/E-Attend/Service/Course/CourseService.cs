using E_Attend.Entities.Repositories;
using E_Attend.Entities.Models;


namespace E_Attend.Service.Course;

public class CourseService : ICourseService {
    private readonly IUnitOfWork unitOfWork;

    public CourseService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> AddCourseAsync(Entities.Models.Course course) {
        await unitOfWork.CourseRepository.AddAsync(course);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> UpdateCourseAsync(int courseId, Entities.Models.Course updatedCourse) {
        var course = await unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.ID == courseId);
        if (course == null) throw new KeyNotFoundException("Course not found.");

        course.InstructorID = updatedCourse.InstructorID;
        course.CreatedAt = updatedCourse.CreatedAt;
        course.Code = updatedCourse.Code;
        course.Name = updatedCourse.Name;
        course.CreditHours = updatedCourse.CreditHours;

        await unitOfWork.CourseRepository.UpdateAsync(course);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<IEnumerable<Entities.Models.Course>> ViewAllCoursesByStudentIDAsync(int studentId) {
        return await unitOfWork.CourseRepository.GetAllAsync(c => 
            unitOfWork.EnrollmentRepository.AnyAsync(e => e.CourseID == c.ID && e.StudentID == studentId).Result);

    }

    public async Task<bool> DeleteCourseAsync(int courseId) {
        var course = await unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.ID == courseId);
        if (course == null) throw new KeyNotFoundException("Course not found.");

        await unitOfWork.CourseRepository.RemoveAsync(course);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<byte[]> DownloadCourseAsync(int courseId) {
        // var course = await unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.ID == courseId);
        // if (course == null) throw new KeyNotFoundException("Course not found.");

        throw new NotImplementedException();
    }
}