using E_Attend.Entities.DTOs;
using E_Attend.Entities.Models;
using E_Attend.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Attend.Service.Lecture {
    public class LectureService : ILectureService {
        private readonly IUnitOfWork _unitOfWork;

        public LectureService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<Entities.Models.Lecture>> AddLectureAsync(Entities.Models.Lecture lecture) {
            try {
                await _unitOfWork.LectureRepository.AddAsync(lecture);
                await _unitOfWork.CompleteAsync();
                return GeneralResponse<Entities.Models.Lecture>.Success(lecture, "Lecture added successfully.");
            }
            catch (Exception ex) {
                return GeneralResponse<Entities.Models.Lecture>.Error($"Error adding lecture: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<object>> UpdateLectureAsync(string lectureId,
            Entities.Models.Lecture updatedLecture) {
            try {
                var lecture = await _unitOfWork.LectureRepository.GetFirstOrDefaultAsync(lec => lec.ID == lectureId);
                if (lecture == null)
                    return GeneralResponse<object>.Error("Lecture not found.");


                lecture.Day = updatedLecture.Day;
                lecture.CourseID = updatedLecture.CourseID;

                await _unitOfWork.LectureRepository.UpdateAsync(lecture);
                await _unitOfWork.CompleteAsync();
                return GeneralResponse<object>.Success(null, "Lecture updated successfully.");
            }
            catch (Exception ex) {
                return GeneralResponse<object>.Error($"Error updating lecture: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<IEnumerable<Entities.Models.Lecture>>> ViewAllLecturesAsync() {
            try {
                var lectures = await _unitOfWork.LectureRepository.GetAllAsync();
                return GeneralResponse<IEnumerable<Entities.Models.Lecture>>.Success(lectures);
            }
            catch (Exception ex) {
                return GeneralResponse<IEnumerable<Entities.Models.Lecture>>.Error(
                    $"Error retrieving lectures: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<Entities.Models.Lecture>> GetLectureByIdAsync(string lectureId) {
            try {
                var lecture = await _unitOfWork.LectureRepository.GetFirstOrDefaultAsync(lec => lec.ID == lectureId);
                if (lecture == null)
                    return GeneralResponse<Entities.Models.Lecture>.Error("Lecture not found.");

                return GeneralResponse<Entities.Models.Lecture>.Success(lecture);
            }
            catch (Exception ex) {
                return GeneralResponse<Entities.Models.Lecture>.Error($"Error retrieving lecture: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<IEnumerable<Entities.Models.Lecture>>> GetLecturesByCourseAsync(
            string courseId) {
            try {
                var lectures = await _unitOfWork.LectureRepository.GetAllAsync(lec => lec.CourseID == courseId);
                return GeneralResponse<IEnumerable<Entities.Models.Lecture>>.Success(lectures);
            }
            catch (Exception ex) {
                return GeneralResponse<IEnumerable<Entities.Models.Lecture>>.Error(
                    $"Error retrieving lectures: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<object>> DeleteLectureAsync(string lectureId) {
            try {
                var lecture = await _unitOfWork.LectureRepository.GetFirstOrDefaultAsync(lec => lec.ID == lectureId);
                if (lecture == null)
                    return GeneralResponse<object>.Error("Lecture not found.");

                await _unitOfWork.LectureRepository.RemoveAsync(lecture);
                await _unitOfWork.CompleteAsync();
                return GeneralResponse<object>.Success(null, "Lecture deleted successfully.");
            }
            catch (Exception ex) {
                return GeneralResponse<object>.Error($"Error deleting lecture: {ex.Message}");
            }
        }

        public async Task<GeneralResponse<IEnumerable<Entities.Models.Student>>> GetStudentsAttendLecture(
            string lectureId) {
            try {
                var lst = await _unitOfWork.AttendanceRepository.GetAllAsync(a =>
                    a.LectureID == lectureId && a.Status == "Present");

                var students = new List<Entities.Models.Student>();

                foreach (var entity in lst) {
                    students.Add(
                        await _unitOfWork.StudentRepository.GetFirstOrDefaultAsync(s => s.ID == entity.StudentID));
                }

                if (lst == null)
                    return GeneralResponse<IEnumerable<Entities.Models.Student>>.Error("students not found.");

                await _unitOfWork.CompleteAsync();
                return GeneralResponse<IEnumerable<Entities.Models.Student>>.Success(students);
            }
            catch (Exception ex) {
                return GeneralResponse<IEnumerable<Entities.Models.Student>>.Error($"Error getting students");
            }
        }

        public async Task<GeneralResponse<IEnumerable<Entities.Models.Lecture>>> GetStudentAttendLecture(string studentId, string courseId) {
            try {
                var lst = await _unitOfWork.AttendanceRepository.GetAllAsync(a =>
                    a.CourseID == courseId && a.Status == "Present" && a.StudentID == studentId);

                var lectures = new List<Entities.Models.Lecture>();

                foreach (var entity in lst) {
                    lectures.Add(
                        await _unitOfWork.LectureRepository.GetFirstOrDefaultAsync(s => s.ID == entity.LectureID));
                }

                if (lst == null)
                    return GeneralResponse<IEnumerable<Entities.Models.Lecture>>.Error("lectures not found.");

                await _unitOfWork.CompleteAsync();
                return GeneralResponse<IEnumerable<Entities.Models.Lecture>>.Success(lectures);
            }
            catch (Exception ex) {
                return GeneralResponse<IEnumerable<Entities.Models.Lecture>>.Error($"Error getting lectures");
            }
        }
    }
}