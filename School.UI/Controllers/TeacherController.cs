using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierSchool.BLL.DTOs.Teacher;
using NTierSchool.BLL.Interfaces;
using NTierSchool.BLL.Services;
using NTierSchool.Entity.Models;

namespace NTierSchool.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetTeachers()
        {
            var teachers = await _service.GetAllWithDetails();

            return Ok(teachers);
        }

        // GET: api/Teacher/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _service.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // POST: api/Teacher
        [HttpPost]
        public async Task<ActionResult<Teacher>> AddTeacher(CreateTeacherDto dto)
        {
            await _service.AddAsync(dto);

            return Ok();
        }

        // PUT: api/Teacher/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherDto dto)
        {
            if (dto.Id == null)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(dto);

            return NoContent(); // güncellensin, görülmek istenirse GetTeacher ile incelenebilir
        }

        // DELETE: api/Teacher/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var teacher = await _service.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
