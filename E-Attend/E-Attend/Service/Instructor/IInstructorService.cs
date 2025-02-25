namespace E_Attend.Service.Instructor
{
    public interface IInstructorService
    {
        Task<bool> AddInstructorAsync(Instructor instructor);
        Task<bool> UpdateInstructorAsync(int instructorId, Instructor updatedInstructor);
        Task<IEnumerable<Instructor>> ViewAllInstructorsAsync();
        Task<bool> DeleteInstructorAsync(int instructorId);
    }
}
