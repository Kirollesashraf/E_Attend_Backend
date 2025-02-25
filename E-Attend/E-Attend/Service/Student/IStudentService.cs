namespace E_Attend.Service.Student
{
    public interface IStudentService
    {
        Task<bool> AddStudentAsync(Entities.Models.Student student);
        Task<bool> UpdateStudentAsync(int studentId, Entities.Models.Student updatedStudent);
        Task<IEnumerable<Entities.Models.Student>> ViewAllStudentsOfSectionAsync(int sectionId);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
