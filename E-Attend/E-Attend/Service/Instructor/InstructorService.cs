using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Instructor;

public class InstructorService : IInstructorService {
    private readonly IUnitOfWork unitOfWork;

    public InstructorService(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> AddInstructorAsync(Entities.Models.Instructor instructor) {
        
        await unitOfWork.InstructorRepository.AddAsync(instructor);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> UpdateInstructorAsync(int instructorId, Entities.Models.Instructor updatedInstructor) {
        var instructor = await unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.ID == instructorId);
        if (instructor == null) throw new KeyNotFoundException("Instructor not found.");

        instructor.Name = updatedInstructor.Name;
        instructor.Department = updatedInstructor.Department;
        instructor.CreatedAt = updatedInstructor.CreatedAt;
        instructor.Specialization = updatedInstructor.Specialization;
        instructor.AcademicDegree = updatedInstructor.AcademicDegree;

        await unitOfWork.InstructorRepository.UpdateAsync(instructor);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<IEnumerable<Entities.Models.Instructor>> ViewAllInstructorsAsync() {
        return await unitOfWork.InstructorRepository.GetAllAsync();
    }

    public async Task<bool> DeleteInstructorAsync(int instructorId) {
        var instructor = await unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.ID == instructorId);
        if (instructor == null) throw new KeyNotFoundException("Instructor not found.");

        await unitOfWork.InstructorRepository.RemoveAsync(instructor);
        await unitOfWork.CompleteAsync();
        return true;
    }
}