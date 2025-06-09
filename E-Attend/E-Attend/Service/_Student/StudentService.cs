using E_Attend.Data.Repositories.Implementation;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Service._Student;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return _unitOfWork.StudentRepository.GetAllAsync(includes: [s=> s.ApplicationUser, s=>s.Courses]);
    }

    public async Task UpdateStudentAsync(string studentId, Student updatedStudent)
    {
        var existingStudent = await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.Id == studentId);
        if (existingStudent != null)
        {
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Degree = updatedStudent.Degree;
            existingStudent.Department = updatedStudent.Department;

            _unitOfWork.StudentRepository.Update(existingStudent);
            await _unitOfWork.CompleteAsync();
        }
        
    }

    public async Task DeleteStudentAsync(string studentId)
    {
        var student = await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.Id == studentId);
        if (student != null)
        {
            _unitOfWork.StudentRepository.Remove(student);
            await _unitOfWork.CompleteAsync();
        }
    }

}