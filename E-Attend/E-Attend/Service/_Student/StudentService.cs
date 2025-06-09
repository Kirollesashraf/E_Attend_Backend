using E_Attend.Data.Repositories.Implementation;
using E_Attend.Entities;

namespace E_Attend.Service._Student;

public class StudentService
{
    private readonly UnitOfWork _unitOfWork;

    public StudentService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return _unitOfWork.StudentRepository.GetAllAsync(includes: [s=> s.ApplicationUser, s=>s.Courses]);
    }
    
}