using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service.Common;

namespace E_Attend.Service._Student;

public interface IStudentService
{
    public Task<GeneralResponse<IEnumerable<StudentCoursesDto>>> GetStudentsAsync();
    public Task<GeneralResponse<string>> DeleteStudentAsync(string studentId);
    public Task<GeneralResponse<string>> UpdateStudentAsync(string studentId, UpdateStudentDto updatedStudent);
}