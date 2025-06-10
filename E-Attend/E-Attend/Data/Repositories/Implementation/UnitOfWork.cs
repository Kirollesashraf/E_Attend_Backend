using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;

namespace E_Attend.Data.Repositories.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public IApplicationUserRepository ApplicationUserRepository { get; private set; }


    public IAttendanceRepository AttendanceRepository { get; private set; }

    public ICourseRepository CourseRepository { get; private set; }

    public IAnnouncementRepository AnnouncementRepository { get; private set; }

    public IInstructorRepository InstructorRepository { get; private set; }

    public IStudentRepository StudentRepository { get; private set; }

    public ILectureRepository LectureRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context;
        this.ApplicationUserRepository = new ApplicationUserRepository(this.context);
        this.AttendanceRepository = new AttendanceRepository(this.context);
        this.CourseRepository = new CourseRepository(this.context);
        this.AnnouncementRepository = new AnnouncementRepository(this.context);
        this.InstructorRepository = new InstructorRepository(this.context);
        this.StudentRepository = new StudentRepository(this.context);
        this.LectureRepository = new LectureRepository(this.context);
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