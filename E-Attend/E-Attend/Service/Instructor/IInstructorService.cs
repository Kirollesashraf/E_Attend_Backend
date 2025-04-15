using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Instructor
{
    public interface IInstructorService
    {
        Task<GeneralResponse<Entities.Models.Instructor>> AddInstructorAsync(Entities.Models.Instructor instructor);
        Task<GeneralResponse<object>> UpdateInstructorAsync(int instructorId, Entities.Models.Instructor updatedInstructor);
        Task<GeneralResponse<IEnumerable<Entities.Models.Instructor>>> ViewAllInstructorsAsync();
        Task<GeneralResponse<object>> DeleteInstructorAsync(int instructorId);
    }
}