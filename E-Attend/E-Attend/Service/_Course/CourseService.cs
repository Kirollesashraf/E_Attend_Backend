using E_Attend.Data.Repositories.Implementation;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Service._Course;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddCourseAsync(Course course)
    {
         _unitOfWork.CourseRepository.AddAsync(course);

        var instructor = await _unitOfWork.InstructorRepository
            .GetFirstOrDefaultAsync(i => i.Id == course.InstructorId, includes: i => i.Courses);

        instructor?.Courses.Add(course);

        await _unitOfWork.CompleteAsync();
    }

    public async Task<Course?> GetCourseAsync(string id)
    {
        return await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(
            c => c.Id == id,
            includes: [c => c.Announcements, c => c.Lectures, c => c.Students, c => c.Instructor]);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _unitOfWork.CourseRepository.GetAllAsync(
            includes: [c => c.Announcements, c => c.Lectures, c => c.Students, c => c.Instructor]);
    }

    public async Task RemoveCourseAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId);
        if (course != null)
        {
            _unitOfWork.CourseRepository.Remove(course);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task UpdateCourseAsync(string courseId, Course updatedCourse)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId);
        if (course != null)
        {
            course.Title = updatedCourse.Title;
            course.Description = updatedCourse.Description;
            course.InstructorId = updatedCourse.InstructorId;
            course.Credits = updatedCourse.Credits;
            course.Code = updatedCourse.Code;
            
            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task AddAnnouncementAsync(string courseId, Announcement announcement)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Announcements);

        course?.Announcements.Add(announcement);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveAnnouncementAsync(string courseId, string announcementId)
    {
        var announcement = await _unitOfWork.AnnouncementRepository
            .GetFirstOrDefaultAsync(a => a.Id == announcementId);
        if (announcement != null)
        {
            _unitOfWork.AnnouncementRepository.Remove(announcement);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task UpdateAnnouncementAsync(string announcementId, Announcement updatedAnnouncement)
    {
        var announcement = await _unitOfWork.AnnouncementRepository
            .GetFirstOrDefaultAsync(a => a.Id == announcementId);
        if (announcement != null)
        {
            announcement.Title = updatedAnnouncement.Title;
            announcement.Content = updatedAnnouncement.Content;

            _unitOfWork.AnnouncementRepository.Update(announcement);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Announcements);

        return course?.Announcements;
    }

    //===========================Lecture===========================

    public async Task AddLectureAsync(string courseId, Lecture lecture)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Lectures);

        course?.Lectures.Add(lecture);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveLectureAsync(string lectureId)
    {
        var lecture = await _unitOfWork.LectureRepository
            .GetFirstOrDefaultAsync(l => l.Id == lectureId);
        if (lecture != null)
        {
            _unitOfWork.LectureRepository.Remove(lecture);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task UpdateLectureAsync(string lectureId, Lecture updatedLecture)
    {
        var lecture = await _unitOfWork.LectureRepository
            .GetFirstOrDefaultAsync(l => l.Id == lectureId);
        if (lecture != null)
        {
            lecture.Title = updatedLecture.Title;
            lecture.Topic = updatedLecture.Topic;
            lecture.Date = updatedLecture.Date;
            lecture.CourseId = updatedLecture.CourseId;
            
            _unitOfWork.LectureRepository.Update(lecture);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<IEnumerable<Lecture>> GetLecturesAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Lectures);

        return course?.Lectures;
    }

    //===========================Student===========================

    public async Task AddStudentAsync(string courseId, Student student)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        course?.Students.Add(student);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveStudentAsync(string courseId, string studentId)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c=>c.Id == courseId, includes: c => c.Students);
       
        var student = await _unitOfWork.StudentRepository
            .GetFirstOrDefaultAsync(s => s.Id == studentId, includes:s=>s.Courses);
        if (student != null)
        {
            course?.Students.Remove(student);
            foreach (var c in student.Courses)
                if (c.Id == courseId)
                {
                    student.Courses.Remove(c);
                    break;
                }
            
            _unitOfWork.StudentRepository.Update(student);
            if (course != null) _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        return course?.Students;
    }
}
