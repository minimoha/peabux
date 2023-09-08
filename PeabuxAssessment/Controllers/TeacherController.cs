using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Interface;

namespace PeabuxAssessment.Controllers
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

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TeacherDTO request)
        {
            var response = await _service.AddTeacher(request);
            if (response.Successful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllTeachers();
            if (response.Successful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _service.Delete(id);
            if (response.Successful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
