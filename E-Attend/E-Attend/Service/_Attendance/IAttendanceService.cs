using E_Attend.Entities;

namespace E_Attend.Service._Attendance;

public interface IAttendanceService
{
    public Task<IEnumerable<Attendance>> GetStudentAttendanceInCourseAsync(string courseId, string studentId);
    public Task<IEnumerable<Attendance>> GetScheduledAttendanceAsync(string courseId);
    public Task<IEnumerable<Attendance>> GetUnscheduledAttendanceAsync(string courseId);
}