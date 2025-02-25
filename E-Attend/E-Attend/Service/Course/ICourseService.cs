namespace E_Attend.Service.Course
{
    public interface ICourseService
    {
        Task<bool> AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(int courseId, Course updatedCourse);
        Task<IEnumerable<Course>> ViewAllCoursesAsync();
        Task<bool> DeleteCourseAsync(int courseId);
        Task<byte[]> DownloadCourseAsync(int courseId);
    }
}
