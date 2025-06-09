using E_Attend.Data.Repositories.Implementation;
using E_Attend.Entities;

namespace E_Attend.Service._Instructor;

public class InstructorService : IInstructorService
{
    private readonly UnitOfWork _unitOfWork;

    public InstructorService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<Instructor>> GetAllInstructorAsync()
    {
        return _unitOfWork.InstructorRepository.GetAllAsync(includes: [i => i.Courses, i => i.ApplicationUser]);
    }
    
}