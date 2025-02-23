using E_Attend.Entities.Repositories;

namespace E_Attend.Data_Access.RepositoryImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAppUserRepository AppUserRepository => throw new NotImplementedException();

        public IAssignmentRepository AssignmentRepository => throw new NotImplementedException();

        public IAttendanceRepository AttendanceRepository => throw new NotImplementedException();

        public ICourseRepository CourseRepository => throw new NotImplementedException();

        public IEnrollmentRepository EnrollmentRepository => throw new NotImplementedException();

        public IInstructorRepository instructorRepository => throw new NotImplementedException();

        public ISheetRepository SheetRepository => throw new NotImplementedException();

        public IStudentRepository StudentRepository => throw new NotImplementedException();

        public ISubmissionRepository submissionRepository => throw new NotImplementedException();

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
