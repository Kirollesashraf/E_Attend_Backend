using E_Attend.Entities;
using E_Attend.Service.Common;

namespace E_Attend.Service._Attendance;

public interface IAttendanceService
{
    public Task<GeneralResponse<string>> AddAttendanceAsync(Attendance attendance);
    public Task<GeneralResponse<IEnumerable<Attendance>>> GetStudentAttendanceInCourseAsync(string courseId, string studentId);
    public Task<GeneralResponse<IEnumerable<Attendance>>> GetScheduledAttendanceAsync(string courseId);
    public Task<GeneralResponse<IEnumerable<Attendance>>> GetUnscheduledAttendanceAsync(string courseId);
}