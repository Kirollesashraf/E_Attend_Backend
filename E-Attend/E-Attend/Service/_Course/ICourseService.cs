using E_Attend.Entities;

namespace E_Attend.Service._Course;

public interface ICourseService
{
    Task AddCourseAsync(Entities.Course course);
    Task<Entities.Course?> GetCourseAsync(string id);
    Task<IEnumerable<Entities.Course>> GetCoursesAsync();
    Task RemoveCourseAsync(Entities.Course course);
    Task UpdateCourseAsync(Entities.Course course);

    Task AddAnnouncementAsync(string id, Announcement announcement);
    Task RemoveAnnouncementAsync(string id, Announcement announcement);
    Task UpdateAnnouncementAsync(string id, Announcement announcement);
    Task<IEnumerable<Entities.Announcement>> GetAnnouncementsAsync(string id);

    Task AddLectureAsync(string id, Lecture lecture);
    Task RemoveLectureAsync(string id, Lecture lecture);
    Task UpdateLectureAsync(string id, Lecture lecture);
    Task<IEnumerable<Lecture>> GetLecturesAsync(string id);

    Task AddStudentAsync(string id, Student student);
    Task RemoveStudentAsync(string id, Student student);
    Task<IEnumerable<Student>> GetStudentsAsync(string id);
}