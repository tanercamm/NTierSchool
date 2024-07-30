using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierSchool.BLL.Services;
using NTierSchool.Entity.Models;

namespace NTierSchool.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly BaseService<Student> _service;

        public StudentController(BaseService<Student> service)
        {
            _service = service;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _service.GetAllAsync();

            return Ok(students);
        }

        // GET: api/Student/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _service.GetEntityAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            await _service.AddAsync(student);

            return CreatedAtAction(nameof(Teacher), new { id = student.Id }, student);
        }

        // PUT: api/Student/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(student);

            return NoContent(); // güncellensin, görülmek istenirse GetStudent ile incelenebilir
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _service.GetEntityAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
