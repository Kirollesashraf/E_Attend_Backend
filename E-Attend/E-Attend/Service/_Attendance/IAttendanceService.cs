using E_Attend.Entities;

namespace E_Attend.Service._Attendance;

public interface IAttendanceService
{
    public Task<IEnumerable<Attendance>> GetStudentAttendanceInCourseAsync(Course course, Student student);
    public Task<IEnumerable<Attendance>> GetScheduledAttendanceAsync(Course course);
    public Task<IEnumerable<Attendance>> GetUnscheduledAttendanceAsync(Course course);
}