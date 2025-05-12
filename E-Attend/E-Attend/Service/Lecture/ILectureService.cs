using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Attend.Service.Lecture
{
    public interface ILectureService
    {
        Task<GeneralResponse<Lecture>> AddLectureAsync(Lecture lecture);
        Task<GeneralResponse<object>> UpdateLectureAsync(string lectureId, Lecture updatedLecture);
        Task<GeneralResponse<IEnumerable<Lecture>>> ViewAllLecturesAsync();
        Task<GeneralResponse<Lecture>> GetLectureByIdAsync(string lectureId);
        Task<GeneralResponse<IEnumerable<Lecture>>> GetLecturesByCourseAsync(string courseId);
        Task<GeneralResponse<object>> DeleteLectureAsync(string lectureId);
    }
}
