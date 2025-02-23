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
        IProfessorRepository ProfessorRepository { get; }
        ISheetRepository SheetRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubmissionRepository SubmissionRepository { get; }




    }
}
