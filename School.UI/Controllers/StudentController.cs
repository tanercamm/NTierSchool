using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierSchool.BLL.DTOs.Student;
using NTierSchool.BLL.Interfaces;
using NTierSchool.BLL.Services;
using NTierSchool.Entity.Models;

namespace NTierSchool.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/Student
        [HttpGet("Details")]
        public async Task<ActionResult<List<Student>>> GetStudentsDetails()
        {
            var students = await _service.GetAllWithDetails();

            return Ok(students);
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
            var student = await _service.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(CreateStudentDto dto)
        {
            await _service.AddAsync(dto);

            return Ok();
        }

        // PUT: api/Student/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDto dto)
        {
            if (dto.Id == null)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(dto);

            return NoContent(); // güncellensin, görülmek istenirse GetStudent ile incelenebilir
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _service.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
