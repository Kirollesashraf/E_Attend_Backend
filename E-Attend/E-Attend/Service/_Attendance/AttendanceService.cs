using E_Attend.Data.Repositories.Implementation;
using E_Attend.Entities;

namespace E_Attend.Service._Attendance;

public class AttendanceService : IAttendanceService
{
    private readonly UnitOfWork _unitOfWork;

    public AttendanceService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<Attendance>> GetStudentAttendanceInCourseAsync(Course course, Student student)
    {
        return _unitOfWork.AttendanceRepository.GetAllAsync(a => a.CourseId == course.Id && a.StudentId == student.Id);
    }

    public Task<IEnumerable<Attendance>> GetScheduledAttendanceAsync(Course course)
    {
        return _unitOfWork.AttendanceRepository.GetAllAsync(a => a.CourseId == course.Id && a.Status == "SCHEDULED");
    }

    public Task<IEnumerable<Attendance>> GetUnscheduledAttendanceAsync(Course course)
    {
        return _unitOfWork.AttendanceRepository.GetAllAsync(a => a.CourseId == course.Id && a.Status == "UNSCHEDULED");
    }
}