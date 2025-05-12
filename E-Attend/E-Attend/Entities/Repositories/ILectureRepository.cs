using E_Attend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Attend.Domain.Repositories
{
    public interface ILectureRepository
    {
        Task<Lecture> GetByIdAsync(string id);
        Task<IEnumerable<Lecture>> GetAllAsync();
        Task<IEnumerable<Lecture>> GetByCourseIdAsync(string courseId);
        Task<IEnumerable<Lecture>> GetByInstructorIdAsync(string instructorId);
        Task<IEnumerable<Lecture>> GetUpcomingLecturesAsync(DateTime fromDate);
        Task<Lecture> AddAsync(Lecture lecture);
        Task UpdateAsync(Lecture lecture);
        Task DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);

    }
}
