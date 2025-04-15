using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Student;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<Entities.Models.Student>> AddStudentAsync(Entities.Models.Student student)
    {
        await unitOfWork.StudentRepository.AddAsync(student);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<Entities.Models.Student>.Success(student, "Student added successfully.");
    }

    public async Task<GeneralResponse<object>> UpdateStudentAsync(int studentId, Entities.Models.Student updatedStudent)
    {
        var student = await unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.ID == studentId);
        if (student == null)
            return GeneralResponse<object>.Error("Student not found.");

        student.Department = updatedStudent.Department;
        student.UniversityID = updatedStudent.UniversityID;
        student.Name = updatedStudent.Name;
        student.CreatedAt = updatedStudent.CreatedAt;

        await unitOfWork.StudentRepository.UpdateAsync(student);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Student updated successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Entities.Models.Student>>> ViewAllStudentsOfSectionAsync(int sectionId)
    {
        // Implement your logic to retrieve students by sectionId.  For now, returning an error:
        return GeneralResponse<IEnumerable<Entities.Models.Student>>.Error("View students by section not implemented.");
    }

    public async Task<GeneralResponse<object>> DeleteStudentAsync(int studentId)
    {
        var student = await unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.ID == studentId);
        if (student == null)
            return GeneralResponse<object>.Error("Student not found.");

        await unitOfWork.StudentRepository.RemoveAsync(student);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Student deleted successfully.");
    }
}