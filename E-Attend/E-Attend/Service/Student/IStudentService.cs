namespace E_Attend.Service.Student
{
    public interface IStudentService
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int studentId, Student updatedStudent);
        Task<IEnumerable<Student>> ViewAllStudentsOfSectionAsync(int sectionId);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
