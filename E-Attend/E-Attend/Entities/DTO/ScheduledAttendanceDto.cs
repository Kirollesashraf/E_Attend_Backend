namespace E_Attend.Entities.DTO;

public class ScheduledAttendanceDto
{
    public int AttendanceId { get; set; }
    public string StudentId { get; set; }
    public string CourseName { get; set; }
    public string TimeSlot { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string Status { get; set; }
}