using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierSchool.BLL.Services;
using NTierSchool.Entity.Models;

namespace NTierSchool.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly BaseService<Teacher> _service;

        public TeacherController(BaseService<Teacher> service)
        {
            _service = service;
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetTeachers()
        {
            var teachers = await _service.GetAllAsync();

            return Ok(teachers);
        }

        // GET: api/Teacher/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _service.GetEntityAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // POST: api/Teacher
        [HttpPost]
        public async Task<ActionResult<Teacher>> AddTeacher(Teacher teacher)
        {
            await _service.AddAsync(teacher);

            return CreatedAtAction(nameof(Teacher), new { id = teacher.Id }, teacher);
        }

        // PUT: api/Teacher/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(teacher);

            return NoContent(); // güncellensin, görülmek istenirse GetTeacher ile incelenebilir
        }

        // DELETE: api/Teacher/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var teacher = await _service.GetEntityAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
