namespace E_Attend.Data.Repositories.Interface;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    Task<int> CompleteAsync();

    IAnnouncementRepository AnnouncementRepository { get; }
    IApplicationUserRepository ApplicationUserRepository { get; }
    IAttendanceRepository AttendanceRepository { get; }
    ICourseRepository CourseRepository { get; }
    IInstructorRepository InstructorRepository { get; }
    IStudentRepository StudentRepository { get; }
    ILectureRepository LectureRepository { get; }
}