using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service.Common;

namespace E_Attend.Service._Instructor;

public interface IInstructorService
{
    public Task<GeneralResponse<IEnumerable<Instructor>>> GetAllInstructorAsync();
    public Task<GeneralResponse<string>> DeleteInstructorAsync(string instructorId);
    public Task<GeneralResponse<string>> UpdateInstructorAsync(string instructorId, UpdateInstructorDto updatedInstructor);
}