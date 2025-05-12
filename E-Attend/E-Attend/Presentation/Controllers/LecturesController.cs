using E_Attend.Domain.Repositories;
using E_Attend.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Attend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
    //     private readonly ILectureRepository _lectureRepository;
    //
    //     public LecturesController(ILectureRepository lectureRepository)
    //     {
    //         _lectureRepository = lectureRepository;
    //     }
    //
    //     [HttpGet]
    //     public async Task<ActionResult<IEnumerable<Lecture>>> GetAllLectures()
    //     {
    //         var lectures = await _lectureRepository.GetAllAsync();
    //         return Ok(lectures);
    //     }
    //
    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<Lecture>> GetLectureById(string id)
    //     {
    //         var lecture = await _lectureRepository.GetByIdAsync(id);
    //         if (lecture == null)
    //         {
    //             return NotFound();
    //         }
    //         return Ok(lecture);
    //     }
    //
    //     [HttpGet("course/{courseId}")]
    //     public async Task<ActionResult<IEnumerable<Lecture>>> GetLecturesByCourse(string courseId)
    //     {
    //         var lectures = await _lectureRepository.GetByCourseIdAsync(courseId);
    //         return Ok(lectures);
    //     }
    //
    //     [HttpGet("upcoming")]
    //     public async Task<ActionResult<IEnumerable<Lecture>>> GetUpcomingLectures()
    //     {
    //         var lectures = await _lectureRepository.GetUpcomingLecturesAsync(DateTime.UtcNow);
    //         return Ok(lectures);
    //     }
    //
    //     [HttpPost]
    //     public async Task<ActionResult<Lecture>> CreateLecture(Lecture lecture)
    //     {
    //         var createdLecture = await _lectureRepository.AddAsync(lecture);
    //         return CreatedAtAction(nameof(GetLectureById), new { id = createdLecture.ID }, createdLecture);
    //     }
    //
    //     [HttpPut("{id}")]
    //     public async Task<IActionResult> UpdateLecture(string id, Lecture lecture)
    //     {
    //         if (id != lecture.ID)
    //         {
    //             return BadRequest();
    //         }
    //
    //         try
    //         {
    //             await _lectureRepository.UpdateAsync(lecture);
    //         }
    //         catch
    //         {
    //             if (!await _lectureRepository.ExistsAsync(id))
    //             {
    //                 return NotFound();
    //             }
    //             throw;
    //         }
    //
    //         return NoContent();
    //     }
    //
    //     [HttpDelete("{id}")]
    //     public async Task<IActionResult> DeleteLecture(string id)
    //     {
    //         await _lectureRepository.DeleteAsync(id);
    //         return NoContent();
    //     }
    }
}
