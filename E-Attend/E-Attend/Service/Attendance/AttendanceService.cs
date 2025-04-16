using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;

// For IActionResult

namespace E_Attend.Service.Attendance;

public class AttendanceService(IUnitOfWork unitOfWork) : IAttendanceService {
    public async Task<GeneralResponse<Entities.Models.Attendance>> ViewAttendanceAsync(int attendanceId) {
        var attendance = await unitOfWork.AttendanceRepository.GetFirstOrDefaultAsync(a => a.ID == attendanceId);
        return attendance == null
            ? GeneralResponse<Entities.Models.Attendance>.Error("Attendance not found")
            : GeneralResponse<Entities.Models.Attendance>.Success(attendance);
    }
}
