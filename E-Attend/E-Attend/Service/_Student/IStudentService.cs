using E_Attend.Entities;

namespace E_Attend.Service._Student;

public interface IStudentService
{
    public Task<IEnumerable<Student>> GetStudentsAsync();
}