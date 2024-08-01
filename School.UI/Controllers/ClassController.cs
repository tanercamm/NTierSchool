using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierSchool.BLL.DTOs.Class;
using NTierSchool.BLL.Interfaces;
using NTierSchool.BLL.Services;
using NTierSchool.Entity.Models;

namespace NTierSchool.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;

        public ClassController(IClassService service)
        {
            _service = service;
        }

        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<List<Class>>> GetClasses()
        {
            var classes = await _service.GetAllWithDetails();

            return Ok(classes);
        }

        // GET: api/Class/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            var c = await _service.GetByIdAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            return Ok(c);
        }

        // POST: api/Class
        [HttpPost]
        public async Task<ActionResult> AddClass(CreateClassDto dto)
        {
            await _service.AddAsync(dto);

            return Ok();
        }

        // PUT: api/Class/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(UpdateClassDto dto)
        {
            if (dto.Id == null)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(dto);

            return NoContent(); // güncellensin, görülmek istenirse GetClass ile incelenebilir
        }

        // DELETE: api/Class/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            var c = await _service.GetByIdAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
