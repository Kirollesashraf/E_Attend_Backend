using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service.Common;

namespace E_Attend.Service._Course;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //===========================Course===========================
    public async Task<GeneralResponse<string>> AddCourseAsync(Course course)
    {
         _unitOfWork.CourseRepository.AddAsync(course);

        var instructor = await _unitOfWork.InstructorRepository
            .GetFirstOrDefaultAsync(i => i.Id == course.InstructorId, includes: i => i.Courses);

        instructor?.Courses.Add(course);

        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Course added successfully.");
    }

    public async Task<GeneralResponse<Course?>> GetCourseAsync(string id)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(
            c => c.Id == id,
            includes: [c => c.Announcements, c => c.Lectures, c => c.Students, c => c.Instructor]);

        if (course == null)
            return GeneralResponse<Course?>.FailureResponse("Course not found.");

        return GeneralResponse<Course?>.SuccessResponse(course);
    }

    public async Task<GeneralResponse<IEnumerable<Course>>> GetCoursesAsync()
    {
        var courses = await _unitOfWork.CourseRepository.GetAllAsync(
            includes: [c => c.Announcements, c => c.Lectures, c => c.Students, c => c.Instructor]);

        return GeneralResponse<IEnumerable<Course>>.SuccessResponse(courses);
    }

    public async Task<GeneralResponse<string>> RemoveCourseAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId);
        if (course == null)
            return GeneralResponse<string>.FailureResponse("Course not found.");

        _unitOfWork.CourseRepository.Remove(course);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Course removed successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateCourseAsync(string courseId, UpdateCourseDto updatedCourse)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId);
        if (course == null)
            return GeneralResponse<string>.FailureResponse("Course not found.");

        course.Title = updatedCourse.Title;
        course.Description = updatedCourse.Description;
        course.InstructorId = updatedCourse.InstructorId;
        course.Credits = updatedCourse.Credits;
        course.Code = updatedCourse.Code;

        _unitOfWork.CourseRepository.Update(course);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Course updated successfully.");
    }

    //===========================Announcement===========================
    public async Task<GeneralResponse<string>> AddAnnouncementAsync(string courseId, Announcement announcement)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Announcements);

        if (course == null)
            return GeneralResponse<string>.FailureResponse("Course not found.");

        course.Announcements.Add(announcement);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Announcement added successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Announcement>>> GetAnnouncementsAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Announcements);

        if (course == null)
            return GeneralResponse<IEnumerable<Announcement>>.FailureResponse("Course not found.");

        return GeneralResponse<IEnumerable<Announcement>>.SuccessResponse(course.Announcements);
    }

    public async Task<GeneralResponse<string>> RemoveAnnouncementAsync(string courseId, string announcementId)
    {
        var announcement = await _unitOfWork.AnnouncementRepository
            .GetFirstOrDefaultAsync(a => a.Id == announcementId);

        if (announcement == null)
            return GeneralResponse<string>.FailureResponse("Announcement not found.");

        _unitOfWork.AnnouncementRepository.Remove(announcement);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Announcement removed successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateAnnouncementAsync(string announcementId, Announcement updatedAnnouncement)
    {
        var announcement = await _unitOfWork.AnnouncementRepository
            .GetFirstOrDefaultAsync(a => a.Id == announcementId);

        if (announcement == null)
            return GeneralResponse<string>.FailureResponse("Announcement not found.");

        announcement.Title = updatedAnnouncement.Title;
        announcement.Content = updatedAnnouncement.Content;

        _unitOfWork.AnnouncementRepository.Update(announcement);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Announcement updated successfully.");
    }

    //===========================Lecture===========================
    public async Task<GeneralResponse<string>> AddLectureAsync(string courseId, Lecture lecture)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Lectures);

        if (course == null)
            return GeneralResponse<string>.FailureResponse("Course not found.");

        course.Lectures.Add(lecture);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Lecture added successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Lecture>>> GetLecturesAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Lectures);

        if (course == null)
            return GeneralResponse<IEnumerable<Lecture>>.FailureResponse("Course not found.");

        return GeneralResponse<IEnumerable<Lecture>>.SuccessResponse(course.Lectures);
    }

    public async Task<GeneralResponse<string>> RemoveLectureAsync(string lectureId)
    {
        var lecture = await _unitOfWork.LectureRepository
            .GetFirstOrDefaultAsync(l => l.Id == lectureId);

        if (lecture == null)
            return GeneralResponse<string>.FailureResponse("Lecture not found.");

        _unitOfWork.LectureRepository.Remove(lecture);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Lecture removed successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateLectureAsync(string lectureId, Lecture updatedLecture)
    {
        var lecture = await _unitOfWork.LectureRepository
            .GetFirstOrDefaultAsync(l => l.Id == lectureId);

        if (lecture == null)
            return GeneralResponse<string>.FailureResponse("Lecture not found.");

        lecture.Title = updatedLecture.Title;
        lecture.Topic = updatedLecture.Topic;
        lecture.Date = updatedLecture.Date;
        lecture.CourseId = updatedLecture.CourseId;

        _unitOfWork.LectureRepository.Update(lecture);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Lecture updated successfully.");
    }

    //===========================Student===========================
    public async Task<GeneralResponse<string>> AddStudentAsync(string courseId, Student student)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        if (course == null)
            return GeneralResponse<string>.FailureResponse("Course not found.");

        course.Students.Add(student);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Student added successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Student>>> GetStudentsAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        if (course == null)
            return GeneralResponse<IEnumerable<Student>>.FailureResponse("Course not found.");

        return GeneralResponse<IEnumerable<Student>>.SuccessResponse(course.Students);
    }

    public async Task<GeneralResponse<string>> RemoveStudentAsync(string courseId, string studentId)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        if (course == null)
            return GeneralResponse<string>.FailureResponse("Course not found.");

        var student = await _unitOfWork.StudentRepository
            .GetFirstOrDefaultAsync(s => s.Id == studentId, includes: s => s.Courses);

        if (student == null)
            return GeneralResponse<string>.FailureResponse("Student not found.");

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
            return GeneralResponse<string>.SuccessResponse("Student removed successfully.");   
        }
        
        return GeneralResponse<string>.FailureResponse("Student cannot be removed");
    }
}
