using E_Attend.Entities;

namespace E_Attend.Service._Instructor;

public interface IInstructorService
{
    public Task<IEnumerable<Instructor>> GetAllInstructorAsync();
    public Task DeleteInstructorAsync(string instructorId);
    public Task UpdateInstructorAsync(string instructorId, Instructor updatedInstructor);
}