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
    public async Task<GeneralResponse<string>> AddCourseAsync(AddCourseDto addCourseDto)
    {
        var course = new Course()
        {
            Id = Guid.NewGuid().ToString(),
            Description = addCourseDto.Description,
            Credits = addCourseDto.Credits,
            InstructorId = addCourseDto.InstructorId,
            Code = addCourseDto.Code,
            Title = addCourseDto.Title
        };
        _unitOfWork.CourseRepository.AddAsync(course);

        var instructor = await _unitOfWork.InstructorRepository
            .GetFirstOrDefaultAsync(i => i.Id == course.InstructorId, includes: i => i.Courses);

        instructor?.Courses.Add(course);


        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Course added successfully.");
    }

    public async Task<GeneralResponse<CourseDto?>> GetCourseAsync(string id)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(
            c => c.Id == id,
            includes: [c => c.Announcements, c => c.Lectures, c => c.Students, c => c.Instructor]);

        if (course == null)
            return GeneralResponse<CourseDto?>.FailureResponse(message:"Course not found.");

        var courseDto = new CourseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            Code = course.Code,
            Credits = course.Credits,
            InstructorId = course.InstructorId
        };

        var studentsDto = course.Students
            .Select(s => new StudentDto
            {
                Id = s.Id,
                UserId = s.UserId,
                Name = s.Name,
                Degree = s.Degree,
                Department = s.Department
            })
            .ToList();

        courseDto.Students = studentsDto;

        return GeneralResponse<CourseDto?>.SuccessResponse(courseDto);
    }

    public async Task<GeneralResponse<Course?>> GetCourseByTitleAsync(string courseTitle)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Title == courseTitle);

        if (course == null)
            return GeneralResponse<Course?>.FailureResponse(message:"Course not found.");

        return GeneralResponse<Course?>.SuccessResponse(course);
    }

    public async Task<GeneralResponse<IEnumerable<Course>>> GetCoursesAsync()
    {
        var courses = await _unitOfWork.CourseRepository.GetAllAsync();

        return GeneralResponse<IEnumerable<Course>>.SuccessResponse(courses);
    }

    public async Task<GeneralResponse<string>> RemoveCourseAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId);
        if (course == null)
            return GeneralResponse<string>.FailureResponse(message:"Course not found.");

        _unitOfWork.CourseRepository.Remove(course);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Course removed successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateCourseAsync(string courseId, UpdateCourseDto updatedCourse)
    {
        var course = await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId);
        if (course == null)
            return GeneralResponse<string>.FailureResponse(message:"Course not found.");

        course.Title = updatedCourse.Title;
        course.Description = updatedCourse.Description;
        course.InstructorId = updatedCourse.InstructorId;
        course.Credits = updatedCourse.Credits;
        course.Code = updatedCourse.Code;

        _unitOfWork.CourseRepository.Update(course);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Course updated successfully.");
    }

    //===========================Announcement===========================
    public async Task<GeneralResponse<string>> AddAnnouncementAsync(string courseId, AddAnnouncementDto announcementDto)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Announcements);

        if (course == null)
            return GeneralResponse<string>.FailureResponse(message:"Course not found.");
        var announcement = new Announcement()
        {
            Content = announcementDto.Content,
            CourseId = course.Id,
            Title = announcementDto.Title,
            Created = announcementDto.Created,
            Id = Guid.CreateVersion7().ToString()
        };

        _unitOfWork.AnnouncementRepository.AddAsync(announcement);
        course.Announcements.Add(announcement);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Announcement added successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Announcement>>> GetAnnouncementsAsync(string courseId)
    {
        return GeneralResponse<IEnumerable<Announcement>>.SuccessResponse(
            await _unitOfWork.AnnouncementRepository.GetAllAsync(a => a.CourseId == courseId));
    }

    public async Task<GeneralResponse<string>> RemoveAnnouncementAsync(string courseId, string announcementId)
    {
        var announcement = await _unitOfWork.AnnouncementRepository
            .GetFirstOrDefaultAsync(a => a.Id == announcementId);

        if (announcement == null)
            return GeneralResponse<string>.FailureResponse(message:"Announcement not found.");

        _unitOfWork.AnnouncementRepository.Remove(announcement);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Announcement removed successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateAnnouncementAsync(string announcementId,
        UpdateAnnouncementDto updatedAnnouncement)
    {
        var announcement = await _unitOfWork.AnnouncementRepository
            .GetFirstOrDefaultAsync(a => a.Id == announcementId);

        if (announcement == null)
            return GeneralResponse<string>.FailureResponse(message:"Announcement not found.");

        announcement.Title = updatedAnnouncement.Title;
        announcement.Content = updatedAnnouncement.Content;

        _unitOfWork.AnnouncementRepository.Update(announcement);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Announcement updated successfully.");
    }

    //===========================Lecture===========================
    public async Task<GeneralResponse<string>> AddLectureAsync(string courseId, AddLectureDto lectureDto)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Lectures);

        if (course == null)
            return GeneralResponse<string>.FailureResponse(message:"Course not found.");

        var lecture = new Lecture()
        {
            CourseId = courseId,
            Title = lectureDto.Title,
            Topic = lectureDto.Topic,
            Id = Guid.CreateVersion7().ToString(),
            Date = DateTime.UtcNow
        };
        _unitOfWork.LectureRepository.AddAsync(lecture);
        course.Lectures.Add(lecture);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Lecture added successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Lecture>>> GetLecturesAsync(string courseId)
    {

        return GeneralResponse<IEnumerable<Lecture>>.SuccessResponse(await _unitOfWork.LectureRepository.GetAllAsync(l => l.CourseId == courseId));
    }

    public async Task<GeneralResponse<string>> RemoveLectureAsync(string lectureId)
    {
        var lecture = await _unitOfWork.LectureRepository
            .GetFirstOrDefaultAsync(l => l.Id == lectureId);

        if (lecture == null)
            return GeneralResponse<string>.FailureResponse(message:"Lecture not found.");

        _unitOfWork.LectureRepository.Remove(lecture);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Lecture removed successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateLectureAsync(string lectureId, UpdateLectureDto updatedLecture)
    {
        var lecture = await _unitOfWork.LectureRepository
            .GetFirstOrDefaultAsync(l => l.Id == lectureId);

        if (lecture == null)
            return GeneralResponse<string>.FailureResponse(message:"Lecture not found.");

        lecture.Title = updatedLecture.Title; 
        lecture.Topic = updatedLecture.Topic;
        lecture.Date = updatedLecture.Date;

        _unitOfWork.LectureRepository.Update(lecture);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Lecture updated successfully.");
    }

    //===========================Student===========================
    public async Task<GeneralResponse<string>> AddStudentAsync(string courseId, string studentId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        if (course == null)
            return GeneralResponse<string>.FailureResponse(message:"Course not found.");

        var student = await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.Id == studentId);
        if (student != null) course.Students.Add(student);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Student added successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<StudentDto>>> GetStudentsAsync(string courseId)
    {
        var course = await _unitOfWork.CourseRepository
            .GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        if (course == null)
            return GeneralResponse<IEnumerable<StudentDto>>.FailureResponse(message:"Course not found.");

        List<StudentDto> studentCourses = new List<StudentDto>();

        foreach (var student in course.Students)
        {
            studentCourses.Add(new StudentDto()
            {
                Degree = student.Degree,
                Department = student.Department,
                Id = student.Id,
                Name = student.Name,
                UserId = student.UserId
            });
        }

        return GeneralResponse<IEnumerable<StudentDto>>.SuccessResponse(studentCourses);
    }

    public async Task<GeneralResponse<string>> RemoveStudentAsync(string courseId, string studentId)
    {
        var course =
            await _unitOfWork.CourseRepository.GetFirstOrDefaultAsync(c => c.Id == courseId, includes: c => c.Students);

        if (course == null)
            return GeneralResponse<string>.FailureResponse(message:"Course not found.");

        var student = await _unitOfWork.StudentRepository
            .GetFirstOrDefaultAsync(s => s.Id == studentId, includes: s => s.Courses);

        if (student == null)
            return GeneralResponse<string>.FailureResponse(message:"Student not found.");

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
            return GeneralResponse<string>.SuccessResponse(message:"Student removed successfully.");
        }

        return GeneralResponse<string>.FailureResponse(message:"Student cannot be removed");
    }
}