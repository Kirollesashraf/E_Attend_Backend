using E_Attend.Entities.DTOs;
using E_Attend.Entities.Repositories;
using E_Attend.Entities.Models;

namespace E_Attend.Service.Instructor;

public class InstructorService : IInstructorService
{
    private readonly IUnitOfWork unitOfWork;

    public InstructorService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<Entities.Models.Instructor>> AddInstructorAsync(Entities.Models.Instructor instructor)
    {
        await unitOfWork.InstructorRepository.AddAsync(instructor);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<Entities.Models.Instructor>.Success(instructor, "Instructor added successfully.");
    }

    public async Task<GeneralResponse<object>> UpdateInstructorAsync(int instructorId, Entities.Models.Instructor updatedInstructor)
    {
        var instructor = await unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.ID == instructorId);
        if (instructor == null)
            return GeneralResponse<object>.Error("Instructor not found.");

        instructor.Name = updatedInstructor.Name;
        instructor.Department = updatedInstructor.Department;
        instructor.CreatedAt = updatedInstructor.CreatedAt;
        instructor.Specialization = updatedInstructor.Specialization;
        instructor.AcademicDegree = updatedInstructor.AcademicDegree;

        await unitOfWork.InstructorRepository.UpdateAsync(instructor);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Instructor updated successfully.");
    }

    public async Task<GeneralResponse<IEnumerable<Entities.Models.Instructor>>> ViewAllInstructorsAsync()
    {
        var instructors = await unitOfWork.InstructorRepository.GetAllAsync();
        return GeneralResponse<IEnumerable<Entities.Models.Instructor>>.Success(instructors);
    }

    public async Task<GeneralResponse<object>> DeleteInstructorAsync(int instructorId)
    {
        var instructor = await unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.ID == instructorId);
        if (instructor == null)
            return GeneralResponse<object>.Error("Instructor not found.");

        await unitOfWork.InstructorRepository.RemoveAsync(instructor);
        await unitOfWork.CompleteAsync();
        return GeneralResponse<object>.Success(null, "Instructor deleted successfully.");
    }
}