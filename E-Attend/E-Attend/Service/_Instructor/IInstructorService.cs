using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service.Common;

namespace E_Attend.Service._Instructor;

public interface IInstructorService
{
    public Task<GeneralResponse<IEnumerable<InstructorDto>>> GetAllInstructorAsync();
    public Task<GeneralResponse<InstructorDto>> GetInstructorByUserIdAsync(string id);
    public Task<GeneralResponse<InstructorDto>> GetInstructorAsync(string id);
    public Task<GeneralResponse<string>> DeleteInstructorAsync(string instructorId);
    public Task<GeneralResponse<string>> UpdateInstructorAsync(string instructorId, UpdateInstructorDto updatedInstructor);
}