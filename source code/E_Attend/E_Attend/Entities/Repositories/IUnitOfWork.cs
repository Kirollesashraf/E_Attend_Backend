namespace E_Attend.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task<int> CompleteAsync();
        IAppUserRepository AppUserRepository { get;}
        IAssignmentRepository AssignmentRepository { get; }
        IAssistantRepository AssistantRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }
        ICourseRepository CourseRepository { get; }
        IEnrollmentRepository EnrollmentRepository { get; }
        IprofessorRepository professorRepository { get; }
        ISheetRepository SheetRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubmissionRepository submissionRepository { get; }




    }
}
