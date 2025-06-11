using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;
using E_Attend.Service.Common;

namespace E_Attend.Service._Attendance;

public class AttendanceService : IAttendanceService
{
    private readonly IUnitOfWork _unitOfWork;

    public AttendanceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<GeneralResponse<string>> AddAttendanceAsync(Attendance attendance)
    {
        var a = await _unitOfWork.AttendanceRepository.GetFirstOrDefaultAsync(aa =>
            aa.StudentId == attendance.StudentId && aa.Date == attendance.Date && aa.TimeSlot == attendance.TimeSlot);
        if (a != null)
        {
            return GeneralResponse<string>.FailureResponse(message:"Attendance cannot be added");
        }

        _unitOfWork.AttendanceRepository.AddAsync(attendance);
        await _unitOfWork.CompleteAsync();

        return GeneralResponse<string>.SuccessResponse(message:"Attendance added");
    }

    public async Task<GeneralResponse<IEnumerable<Attendance>>> GetStudentAttendanceInCourseAsync(string courseId,
        string studentId)
    {
        var attendances = await _unitOfWork.AttendanceRepository
            .GetAllAsync(a => a.CourseId == courseId && a.StudentId == studentId, includes: [a=>a.Student, a=>a.Course]);
        return GeneralResponse<IEnumerable<Attendance>>.SuccessResponse(attendances);
    }

    public async Task<GeneralResponse<IEnumerable<Attendance>>> GetScheduledAttendanceAsync(string courseId)
    {
        var attendances = await _unitOfWork.AttendanceRepository
            .GetAllAsync(a => a.CourseId == courseId && a.Status.StartsWith("SCHEDULED"), includes: [a=>a.Student, a=>a.Course]);
        return GeneralResponse<IEnumerable<Attendance>>.SuccessResponse(attendances);
    }

    public async Task<GeneralResponse<IEnumerable<Attendance>>> GetUnscheduledAttendanceAsync(string courseId)
    {
        var attendances = await _unitOfWork.AttendanceRepository
            .GetAllAsync(a => a.CourseId == courseId && a.Status.StartsWith("UNSCHEDULED"), includes: [a=>a.Student, a=>a.Course]);
        return GeneralResponse<IEnumerable<Attendance>>.SuccessResponse(attendances);
    }
}