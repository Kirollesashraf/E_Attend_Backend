using E_Attend.Entities;

namespace E_Attend.Service._Course;


public interface ICourseService
{
    //===========================Course===========================
    Task AddCourseAsync(Course course);
    Task<Course?> GetCourseAsync(string id);
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task RemoveCourseAsync(string courseId);
    Task UpdateCourseAsync(string courseId, Course updatedCourse);

    //===========================Announcement===========================
    Task AddAnnouncementAsync(string courseId, Announcement announcement);
    Task<IEnumerable<Announcement>> GetAnnouncementsAsync(string courseId);
    Task RemoveAnnouncementAsync(string courseId, string announcementId);
    Task UpdateAnnouncementAsync(string announcementId, Announcement updatedAnnouncement);

    //===========================Lecture===========================
    Task AddLectureAsync(string courseId, Lecture lecture);
    Task<IEnumerable<Lecture>> GetLecturesAsync(string courseId);
    Task RemoveLectureAsync(string lectureId);
    Task UpdateLectureAsync(string lectureId, Lecture updatedLecture);

    //===========================Student===========================
    Task AddStudentAsync(string courseId, Student student);
    Task<IEnumerable<Student>> GetStudentsAsync(string courseId);
    Task RemoveStudentAsync(string courseId, string studentId);
}