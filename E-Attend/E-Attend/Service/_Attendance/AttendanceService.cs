using E_Attend.Data.Repositories.Implementation;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Service._Attendance;

public class AttendanceService : IAttendanceService
{
    private readonly IUnitOfWork _unitOfWork;

    public AttendanceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // public Task FetchLatestAttendanceAsync()
    // {
    //     
    // }
    public Task<IEnumerable<Attendance>> GetStudentAttendanceInCourseAsync(string courseId, string studentId)
    {
        return _unitOfWork.AttendanceRepository.GetAllAsync(a => a.CourseId == courseId && a.StudentId == studentId);
    }

    public Task<IEnumerable<Attendance>> GetScheduledAttendanceAsync(string courseId)
    {
        return _unitOfWork.AttendanceRepository.GetAllAsync(a => a.CourseId == courseId && a.Status == "SCHEDULED");
    }

    public Task<IEnumerable<Attendance>> GetUnscheduledAttendanceAsync(string courseId)
    {
        return _unitOfWork.AttendanceRepository.GetAllAsync(a => a.CourseId == courseId && a.Status == "UNSCHEDULED");
    }

}