using Microsoft.AspNetCore.Mvc;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Interface;

namespace PeabuxAssessment.Controllers
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
        [HttpPost("Create")]
        public async Task<IActionResult> AddStudent(StudentDTO request)
        {
            var response = await _service.AddStudent(request);
            if (response.Successful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllStudents();
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
