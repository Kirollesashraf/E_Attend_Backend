using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Course
{
    public interface ICourseService
    {
        Task<GeneralResponse<Entities.Models.Course>> AddCourseAsync(Entities.Models.Course course);
        Task<GeneralResponse<object>> UpdateCourseAsync(int courseId, Entities.Models.Course updatedCourse);
        Task<GeneralResponse<IEnumerable<Entities.Models.Course>>> ViewAllCoursesByStudentIDAsync(int studentId);
        Task<IEnumerable<Entities.Models.Course>> ViewAllCourses();
        Task<GeneralResponse<object>> DeleteCourseAsync(int courseId);
        Task<GeneralResponse<byte[]>> DownloadCourseAsync(int courseId); // Keep consistent return type
    }
}