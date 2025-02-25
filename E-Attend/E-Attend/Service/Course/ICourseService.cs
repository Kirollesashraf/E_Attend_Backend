namespace E_Attend.Service.Course
{
    public interface ICourseService
    {
        Task<bool> AddCourseAsync(Entities.Models.Course course);
        Task<bool> UpdateCourseAsync(int courseId, Entities.Models.Course updatedCourse);
        Task<IEnumerable<Entities.Models.Course>> ViewAllCoursesByStudentIDAsync(int studentId);
        Task<bool> DeleteCourseAsync(int courseId);
        Task<byte[]> DownloadCourseAsync(int courseId);
    }
}
