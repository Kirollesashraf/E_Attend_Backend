namespace E_Attend.Service.Instructor
{
    public interface IInstructorService
    {
        Task<bool> AddInstructorAsync(Entities.Models.Instructor instructor);
        Task<bool> UpdateInstructorAsync(int instructorId, Entities.Models.Instructor updatedInstructor);
        Task<IEnumerable<Entities.Models.Instructor>> ViewAllInstructorsAsync();
        Task<bool> DeleteInstructorAsync(int instructorId);
    }
}
