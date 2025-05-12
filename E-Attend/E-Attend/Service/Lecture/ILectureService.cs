using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Attend.Service.Lecture
{
    public interface ILectureService
    {
        Task<GeneralResponse<Entities.Models.Lecture>> AddLectureAsync(Entities.Models.Lecture lecture);
        Task<GeneralResponse<object>> UpdateLectureAsync(string lectureId, Entities.Models.Lecture updatedLecture);
        Task<GeneralResponse<IEnumerable<Entities.Models.Lecture>>> ViewAllLecturesAsync();
        Task<GeneralResponse<Entities.Models.Lecture>> GetLectureByIdAsync(string lectureId);
        Task<GeneralResponse<IEnumerable<Entities.Models.Lecture>>> GetLecturesByCourseAsync(string courseId);
        Task<GeneralResponse<object>> DeleteLectureAsync(string lectureId);
        Task<GeneralResponse<IEnumerable<Entities.Models.Student>>> GetStudentsAttendLecture(string lectureId);
        Task<GeneralResponse<IEnumerable<Entities.Models.Lecture>>> GetStudentAttendLecture(string studentId, string courseId);
    }
}
