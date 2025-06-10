using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;
using E_Attend.Entities.DTO;
using E_Attend.Service.Common;

namespace E_Attend.Service._Student;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<IEnumerable<StudentDto>>> GetStudentsAsync()
    {
        var students = await _unitOfWork.StudentRepository.GetAllAsync(
            includes: [s => s.Courses]);

        var studentsDto = students.Select(s => new StudentDto
        {
            Id = s.Id,
            UserId = s.UserId,
            Name = s.Name,
            Degree = s.Degree,
            Department = s.Department,
            Courses = s.Courses?.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Code = c.Code,
                Credits = c.Credits,
                InstructorId = c.InstructorId
            }).ToList()
        }).ToList();

        return GeneralResponse<IEnumerable<StudentDto>>.SuccessResponse(studentsDto);
    }
    
    public async Task<GeneralResponse<StudentDto>> GetStudentAsync(string studentId)
    {
        var student = await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s=>s.Id == studentId,
            includes: [s => s.Courses]);


        if (student == null)
        {
            return GeneralResponse<StudentDto>.FailureResponse(message:"Student not found.");
        }

        var studentDto = new StudentDto
        {
            Id = student.Id,
            UserId = student.UserId,
            Name = student.Name,
            Degree = student.Degree,
            Department = student.Department,
            Courses = student.Courses?.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Code = c.Code,
                Credits = c.Credits,
                InstructorId = c.InstructorId
            }).ToList()
        };

        return GeneralResponse<StudentDto>.SuccessResponse(studentDto);
    }



    public async Task<GeneralResponse<string>> UpdateStudentAsync(string studentId, UpdateStudentDto updatedStudent)
    {
        var existingStudent = await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.Id == studentId);
        if (existingStudent == null)
        {
            return GeneralResponse<string>.FailureResponse("Student not found.");
        }

        existingStudent.Name = updatedStudent.Name;
        existingStudent.Degree = updatedStudent.Degree;
        existingStudent.Department = updatedStudent.Department;

        _unitOfWork.StudentRepository.Update(existingStudent);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Student updated successfully.");
    }

    public async Task<GeneralResponse<string>> DeleteStudentAsync(string studentId)
    {
        var student = await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.Id == studentId);
        if (student == null)
        {
            return GeneralResponse<string>.FailureResponse("Student not found.");
        }

        _unitOfWork.StudentRepository.Remove(student);
        await _unitOfWork.CompleteAsync();
        return GeneralResponse<string>.SuccessResponse("Student deleted successfully.");
    }
}