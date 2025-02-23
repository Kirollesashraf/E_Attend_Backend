using E_Attend.Data_Access.context;
using E_Attend.Entities.Repositories;

namespace E_Attend.Data_Access.RepositoryImplementation
{
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationDbContext context;
        public IAppUserRepository AppUserRepository { get; private set;  }

        public IAssignmentRepository AssignmentRepository{ get; private set; }

        public IAssistantRepository AssistantRepository { get; private set; }

        public IAttendanceRepository AttendanceRepository { get; private set; }

        public ICourseRepository CourseRepository{ get; private set; }

        public IEnrollmentRepository EnrollmentRepository { get; private set; }

        public IProfessorRepository ProfessorRepository { get; private set; }

        public ISheetRepository SheetRepository { get; private set; }

        public IStudentRepository StudentRepository { get; private set; }

        public ISubmissionRepository SubmissionRepository{ get; private set; }

        public UnitOfWork(ApplicationDbContext context) {
            this.context = context;
            this.AppUserRepository = new AppUserRepository(this.context);
            this.AssignmentRepository = new AssignmentRepository(this.context);
            this.AssistantRepository = new AssistantRepository(this.context);
            this.AttendanceRepository = new AttendanceRepository(this.context);
            this.CourseRepository = new CourseRepository(this.context);
            this.EnrollmentRepository = new EnrollmentRepository(this.context);
            this.ProfessorRepository = new ProfessorRepository(this.context);
            this.SheetRepository = new SheetsRepository(this.context);
            this.StudentRepository = new StudentsRepository(this.context);
            this.SubmissionRepository = new SubmissionRepository(this.context);
        }
        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
