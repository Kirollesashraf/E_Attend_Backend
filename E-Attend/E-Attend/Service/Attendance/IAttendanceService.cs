// IAssignmentService.cs (Interface)

using E_Attend.Entities.DTOs;

namespace E_Attend.Service.Attendance;

public interface IAttendanceService
{
    Task<GeneralResponse<Entities.Models.Attendance>> ViewAttendanceAsync(int attendanceId);

}