using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierSchool.BLL.Interfaces;
using NTierSchool.BLL.Services;
using NTierSchool.Entity.Models;

namespace NTierSchool.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;

        public SchoolController(ISchoolService service)
        {
            _service = service;
        }

        // GET: api/School
        [HttpGet]
        public async Task<ActionResult<List<School>>> GetSchools()
        {
            var schools = await _service.GetAllWithIncludes();

            return Ok(schools);
        }

        // GET: api/School/1
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _service.GetEntityAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // POST: api/School
        [HttpPost]
        public async Task<ActionResult<School>> AddSchool(School school)
        {
            await _service.AddAsync(school);

            return CreatedAtAction(nameof(School), new { id = school.Id }, school);
        }

        // PUT: api/School/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(school);

            return NoContent(); // güncellensin, görülmek istenirse GetSchool ile incelenebilir
        }

        // DELETE: api/School/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSchool(int id)
        {
            var school = await _service.GetEntityAsync(id);

            if (school == null)
            {
                return BadRequest();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
