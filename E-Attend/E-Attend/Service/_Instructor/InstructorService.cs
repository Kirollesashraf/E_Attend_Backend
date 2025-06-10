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

   public async Task<GeneralResponse<IEnumerable<InstructorDto>>> GetAllInstructorAsync()
   {
       var instructors = await _unitOfWork.InstructorRepository.GetAllAsync(includes: i => i.Courses);

        if (instructors == null || !instructors.Any())
        {
            return GeneralResponse<IEnumerable<InstructorDto>>.FailureResponse("No instructors found.");
        }

        var instructorsDto = instructors.Select(s => new InstructorDto
        {
            Id = s.Id,
            UserId = s.UserId,
            Name = s.Name,
            UniversityId = s.UniversityId,
            Degree = s.Degree,
            Specialization = s.Specialization,
            Department = s.Department,
            Courses = s.Courses?.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Code = c.Code,
                Credits = c.Credits,
                InstructorId = c.InstructorId
            }).ToList() ?? new List<CourseDto>()
        }).ToList();

        return GeneralResponse<IEnumerable<InstructorDto>>.SuccessResponse(instructorsDto);
    }

    public async Task<GeneralResponse<InstructorDto>> GetInstructorAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return GeneralResponse<InstructorDto>.FailureResponse(message:"Instructor ID cannot be null or empty.");
        }

        var instructor =
                await _unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.Id == id, includes: i => i.Courses)
            ;
        if (instructor == null)
        {
            return GeneralResponse<InstructorDto>.FailureResponse(message:$"Instructor with ID '{id}' not found.");
        }

        var instructorDto = new InstructorDto
        {
            Id = instructor.Id,
            UserId = instructor.UserId,
            Name = instructor.Name,
            UniversityId = instructor.UniversityId,
            Degree = instructor.Degree,
            Specialization = instructor.Specialization,
            Department = instructor.Department,
            Courses = instructor.Courses?.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Code = c.Code,
                Credits = c.Credits,
                InstructorId = c.InstructorId
            }).ToList() ?? new List<CourseDto>()
        };

        return GeneralResponse<InstructorDto>.SuccessResponse(instructorDto);
    }
    public async Task<GeneralResponse<string>> DeleteInstructorAsync(string instructorId)
    {
        var instructor = await _unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.Id == instructorId);
        if (instructor == null)
        {
            return GeneralResponse<string>.FailureResponse(message:"Instructor not found.");
        }

        _unitOfWork.InstructorRepository.Remove(instructor);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Instructor deleted successfully.");
    }

    public async Task<GeneralResponse<string>> UpdateInstructorAsync(string instructorId, UpdateInstructorDto updatedInstructor)
    {
        var existingInstructor = await _unitOfWork.InstructorRepository.GetFirstOrDefaultAsync(i => i.Id == instructorId);
        if (existingInstructor == null)
        {
            return GeneralResponse<string>.FailureResponse(message:"Instructor not found.");
        }

        existingInstructor.Name = updatedInstructor.Name;
        existingInstructor.UniversityId = updatedInstructor.UniversityId;
        existingInstructor.Department = updatedInstructor.Department;
        existingInstructor.Degree = updatedInstructor.Degree;
        existingInstructor.Specialization = updatedInstructor.Specialization;

        _unitOfWork.InstructorRepository.Update(existingInstructor);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse(message:"Instructor updated successfully.");
    }
}
