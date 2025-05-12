using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using E_Attend.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Attend.Service.Lecture
{
    public class LectureService : ILectureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LectureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<Lecture>> AddLectureAsync(Lecture lecture)
        {
            try
            {
                await _unitOfWork.Lectures.AddAsync(lecture);
                await _unitOfWork.CompleteAsync();
                return GeneralResponse<Lecture>.Success(lecture, "Lecture added successfully.");
            }
            catch (Exception ex)
            {
                return GeneralResponse<Lecture>.Error($"Error adding lecture: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<object>> UpdateLectureAsync(string lectureId, Lecture updatedLecture)
        {
            try
            {
                var lecture = await _unitOfWork.Lectures.GetByIdAsync(lectureId);
                if (lecture == null)
                    return GeneralResponse<object>.Error("Lecture not found.");

                lecture.Title = updatedLecture.Title;
                lecture.StartTime = updatedLecture.StartTime;
                lecture.EndTime = updatedLecture.EndTime;
                lecture.Location = updatedLecture.Location;
                lecture.CourseID = updatedLecture.CourseID;

                await _unitOfWork.Lectures.UpdateAsync(lecture);
                await _unitOfWork.CompleteAsync();
                return GeneralResponse<object>.Success(null, "Lecture updated successfully.");
            }
            catch (Exception ex)
            {
                return GeneralResponse<object>.Error($"Error updating lecture: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<IEnumerable<Lecture>>> ViewAllLecturesAsync()
        {
            try
            {
                var lectures = await _unitOfWork.Lectures.GetAllAsync();
                return GeneralResponse<IEnumerable<Lecture>>.Success(lectures);
            }
            catch (Exception ex)
            {
                return GeneralResponse<IEnumerable<Lecture>>.Error($"Error retrieving lectures: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<Lecture>> GetLectureByIdAsync(string lectureId)
        {
            try
            {
                var lecture = await _unitOfWork.Lectures.GetByIdAsync(lectureId);
                if (lecture == null)
                    return GeneralResponse<Lecture>.Error("Lecture not found.");

                return GeneralResponse<Lecture>.Success(lecture);
            }
            catch (Exception ex)
            {
                return GeneralResponse<Lecture>.Error($"Error retrieving lecture: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<IEnumerable<Lecture>>> GetLecturesByCourseAsync(string courseId)
        {
            try
            {
                var lectures = await _unitOfWork.Lectures.GetByCourseIdAsync(courseId);
                return GeneralResponse<IEnumerable<Lecture>>.Success(lectures);
            }
            catch (Exception ex)
            {
                return GeneralResponse<IEnumerable<Lecture>>.Error($"Error retrieving lectures: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<object>> DeleteLectureAsync(string lectureId)
        {
            try
            {
                var lecture = await _unitOfWork.Lectures.GetByIdAsync(lectureId);
                if (lecture == null)
                    return GeneralResponse<object>.Error("Lecture not found.");

                await _unitOfWork.Lectures.DeleteAsync(lectureId);
                await _unitOfWork.CompleteAsync();
                return GeneralResponse<object>.Success(null, "Lecture deleted successfully.");
            }
            catch (Exception ex)
            {
                return GeneralResponse<object>.Error($"Error deleting lecture: {ex.Message}");
            }
        }
    }
}
