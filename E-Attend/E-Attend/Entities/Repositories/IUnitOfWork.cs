namespace E_Attend.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task<int> CompleteAsync();
        
        IAppUserRepository AppUserRepository { get;}
        IAssignmentRepository AssignmentRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }
        ICourseRepository CourseRepository { get; }
        IEnrollmentRepository EnrollmentRepository { get; }
        IInstructorRepository InstructorRepository { get; }
        ISheetRepository SheetRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubmissionRepository SubmissionRepository { get; }




    }
}
