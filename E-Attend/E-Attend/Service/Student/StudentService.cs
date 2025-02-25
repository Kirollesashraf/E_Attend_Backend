using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Student;

public class StudentService : IStudentService{
    private readonly IUnitOfWork unitOfWork;

    public StudentService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> AddStudentAsync(Entities.Models.Student student) {
        await unitOfWork.StudentRepository.AddAsync(student);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> UpdateStudentAsync(int studentId, Entities.Models.Student updatedStudent) {
        var student = await unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.ID == studentId);
        if (student == null) throw new KeyNotFoundException("Student not found.");
        
        student.Department = updatedStudent.Department;
        student.UniversityID = updatedStudent.UniversityID;
        student.Name = updatedStudent.Name;
        student.CreatedAt = updatedStudent.CreatedAt;

        await unitOfWork.StudentRepository.UpdateAsync(student);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<IEnumerable<Entities.Models.Student>> ViewAllStudentsOfSectionAsync(int sectionId) {
        // return await unitOfWork.StudentRepository.GetAllAsync(s => s. == sectionId);
        
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteStudentAsync(int studentId) {
        var student = await unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.ID == studentId);
        if (student == null) throw new KeyNotFoundException("Student not found.");

        await unitOfWork.StudentRepository.RemoveAsync(student);
        await unitOfWork.CompleteAsync();
        return true;
    }
}