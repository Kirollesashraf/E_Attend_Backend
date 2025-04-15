using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Student
{
    public interface IStudentService
    {
        Task<GeneralResponse<Entities.Models.Student>> AddStudentAsync(Entities.Models.Student student);
        Task<GeneralResponse<object>> UpdateStudentAsync(int studentId, Entities.Models.Student updatedStudent);
        Task<GeneralResponse<IEnumerable<Entities.Models.Student>>> ViewAllStudentsOfSectionAsync(int sectionId);
        Task<GeneralResponse<object>> DeleteStudentAsync(int studentId);
    }
}