using E_Attend.Data_Access.context;
using E_Attend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Attend.Domain.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly ApplicationDbContext _context;

        public LectureRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Lecture> GetByIdAsync(string id)
        {
            return await _context.Lectures
                .Include(l => l.Course)
                .FirstOrDefaultAsync(l => l.ID == id);
        }

        public async Task<IEnumerable<Lecture>> GetAllAsync()
        {
            return await _context.Lectures
                .Include(l => l.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lecture>> GetByCourseIdAsync(string courseId)
        {
            return await _context.Lectures
                .Where(l => l.CourseID == courseId)
                .Include(l => l.Course)
                .OrderBy(l => l.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lecture>> GetByInstructorIdAsync(string instructorId)
        {
            return await _context.Lectures
                .Include(l => l.Course)
                .Where(l => l.Course.InstructorID == instructorId)
                .OrderBy(l => l.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lecture>> GetUpcomingLecturesAsync(DateTime fromDate)
        {
            return await _context.Lectures
                .Where(l => l.StartTime >= fromDate)
                .Include(l => l.Course)
                .OrderBy(l => l.StartTime)
                .ToListAsync();
        }

        public async Task<Lecture> AddAsync(Lecture lecture)
        {
            if (lecture == null)
                throw new ArgumentNullException(nameof(lecture));

            lecture.CreatedAt = DateTime.UtcNow;
            await _context.Lectures.AddAsync(lecture);
            await _context.SaveChangesAsync();
            return lecture;
        }

        public async Task UpdateAsync(Lecture lecture)
        {
            if (lecture == null)
                throw new ArgumentNullException(nameof(lecture));

            _context.Lectures.Update(lecture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture != null)
            {
                _context.Lectures.Remove(lecture);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Lectures.AnyAsync(l => l.ID == id);
        }
    }
}
