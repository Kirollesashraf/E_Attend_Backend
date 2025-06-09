using E_Attend.Data.Repositories.Implementation;
using E_Attend.Entities;

namespace E_Attend.Service._Course;

public class CourseService : ICourseService
{
    private readonly UnitOfWork _unitOfWork;

    public CourseService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddCourseAsync(Course course)
    {
        _unitOfWork.CourseRepository.AddAsync(course);
        
        var instructor = await _unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i =>i.Id  == course.InstructorId, includes: i => i.Courses );
        instructor?.Courses.Add(course);
        
        await _unitOfWork.CompleteAsync();
    }

    public async Task<Course?> GetCourseAsync(string id)
    {
        return await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == id,
            includes: [c => c.Announcements, c => c.Lectures, c => c.Students, c => c.Instructor]);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _unitOfWork.CourseRepository.GetAllAsync(includes:
            [c => c.Announcements, c => c.Lectures, c => c.Students, c => c.Instructor]);
    }

    public async Task RemoveCourseAsync(Entities.Course course)
    {
        _unitOfWork.CourseRepository.Remove(course);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateCourseAsync(Entities.Course course)
    {
        _unitOfWork.CourseRepository.Update(course);
        await _unitOfWork.CompleteAsync();
    }

    public async Task AddAnnouncementAsync(string id, Announcement announcement)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Announcements);

        course?.Announcements.Add(announcement);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveAnnouncementAsync(string id, Announcement announcement)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Announcements);

        course?.Announcements.Remove(announcement);
        _unitOfWork.AnnouncementRepository.Remove(announcement);

        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAnnouncementAsync(string id, Announcement announcement)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Announcements);

        course?.Announcements.Remove(announcement);
        course?.Announcements.Add(announcement);

        _unitOfWork.AnnouncementRepository.Update(announcement);

        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<Entities.Announcement>> GetAnnouncementsAsync(string id)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Announcements);

        return course?.Announcements;
    }

    //==========================================Lecture===========================================
    public async Task AddLectureAsync(string id, Lecture lecture)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Lectures);

        course?.Lectures.Add(lecture);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveLectureAsync(string id, Lecture lecture)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Lectures);

        course?.Lectures.Remove(lecture);
        _unitOfWork.LectureRepository.Remove(lecture);

        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateLectureAsync(string id, Lecture lecture)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Lectures);
        course?.Lectures.Remove(lecture);
        course?.Lectures.Add(lecture);

        _unitOfWork.LectureRepository.Update(lecture);

        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<Lecture>> GetLecturesAsync(string id)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Lectures);

        return course?.Lectures;
    }

    //==========================================Student===========================================

    public async Task AddStudentAsync(string id, Student student)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Students);

        var stud = await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(predicate: s => s.Id == id,
            includes: s => s.Courses);


        stud?.Courses.Add(course);
        course?.Students.Add(student);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveStudentAsync(string id, Student student)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Students);

        course?.Students.Remove(student);
        _unitOfWork.StudentRepository.Remove(student);

        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync(string id)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == id,
                includes: c => c.Students);

        return course?.Students;
    }
}