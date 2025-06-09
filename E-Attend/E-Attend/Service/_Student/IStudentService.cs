using E_Attend.Entities;

namespace E_Attend.Service._Student;

public interface IStudentService
{
    public Task<IEnumerable<Student>> GetStudentsAsync();
    public Task DeleteStudentAsync(string studentId);
    public Task UpdateStudentAsync(string studentId, Student updatedStudent);
}