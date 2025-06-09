using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service.Common;

namespace E_Attend.Service._Course
{
    public interface ICourseService
    {
        //===========================Course===========================
        Task<GeneralResponse<string>> AddCourseAsync(Course course);
        Task<GeneralResponse<Course?>> GetCourseAsync(string id);
        Task<GeneralResponse<IEnumerable<Course>>> GetCoursesAsync();
        Task<GeneralResponse<string>> RemoveCourseAsync(string courseId);
        Task<GeneralResponse<string>> UpdateCourseAsync(string courseId, UpdateCourseDto updatedCourse);

        //===========================Announcement===========================
        Task<GeneralResponse<string>> AddAnnouncementAsync(string courseId, Announcement announcement);
        Task<GeneralResponse<IEnumerable<Announcement>>> GetAnnouncementsAsync(string courseId);
        Task<GeneralResponse<string>> RemoveAnnouncementAsync(string courseId, string announcementId);
        Task<GeneralResponse<string>> UpdateAnnouncementAsync(string announcementId, Announcement updatedAnnouncement);

        //===========================Lecture===========================
        Task<GeneralResponse<string>> AddLectureAsync(string courseId, Lecture lecture);
        Task<GeneralResponse<IEnumerable<Lecture>>> GetLecturesAsync(string courseId);
        Task<GeneralResponse<string>> RemoveLectureAsync(string lectureId);
        Task<GeneralResponse<string>> UpdateLectureAsync(string lectureId, Lecture updatedLecture);

        //===========================Student===========================
        Task<GeneralResponse<string>> AddStudentAsync(string courseId, Student student);
        Task<GeneralResponse<IEnumerable<Student>>> GetStudentsAsync(string courseId);
        Task<GeneralResponse<string>> RemoveStudentAsync(string courseId, string studentId);
    }
}