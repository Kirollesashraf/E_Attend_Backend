using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service.Common;

namespace E_Attend.Service._Instructor;

public class InstructorService : IInstructorService
{
    private readonly IUnitOfWork _unitOfWork;

    public InstructorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<IEnumerable<Instructor>>> GetAllInstructorAsync()
    {
        var instructors = await _unitOfWork.InstructorRepository.GetAllAsync(
            includes: [i => i.Courses, i => i.ApplicationUser]);
        return GeneralResponse<IEnumerable<Instructor>>.SuccessResponse(instructors);
    }

    public async Task<GeneralResponse<string>> DeleteInstructorAsync(string instructorId)
    {
        var instructor = await _unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.Id == instructorId);
        if (instructor == null)
        {
            return GeneralResponse<string>.FailureResponse("Instructor not found.");
        }

        _unitOfWork.InstructorRepository.Remove(instructor);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Instructor deleted successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateInstructorAsync(string instructorId, UpdateInstructorDto updatedInstructor)
    {
        var existingInstructor = await _unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.Id == instructorId);
        if (existingInstructor == null)
        {
            return GeneralResponse<string>.FailureResponse("Instructor not found.");
        }

        existingInstructor.Name = updatedInstructor.Name;
        existingInstructor.UniversityId = updatedInstructor.UniversityId;
        existingInstructor.Department = updatedInstructor.Department;
        existingInstructor.Degree = updatedInstructor.Degree;
        existingInstructor.Specialization = updatedInstructor.Specialization;

        _unitOfWork.InstructorRepository.Update(existingInstructor);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Instructor updated successfully.");
    }
}
