using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Services;

namespace SchoolManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentMarkController : ControllerBase
    {
        private readonly IStudentMarkService _studentMarkService;
        private readonly ILogger<StudentMarkController> _logger;

        public StudentMarkController(IStudentMarkService studentMarkService, ILogger<StudentMarkController> logger)
        {
            _studentMarkService = studentMarkService;
            _logger = logger;
        }

        // GET: api/StudentMark
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var studentMarks = await _studentMarkService.GetAllStudentMarksAsync();
            return Ok(studentMarks);
        }

        // GET: api/StudentMark/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentMark = await _studentMarkService.GetStudentMarkByIdAsync(id);
            if (studentMark == null)
            {
                return NotFound();
            }
            return Ok(studentMark);
        }

        //// POST: api/StudentMark
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] StudentMarkDTO studentMarkDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _studentMarkService.CreatetudentMarkAsync(studentMarkDto);
        //    return CreatedAtAction(nameof(GetById), new { id = studentMarkDto.GradeID }, studentMarkDto);
        //}

        // PUT: api/StudentMark/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentMarkDTO studentMarkDto)
        {
            if (id != studentMarkDto.GradeID)
            {
                return BadRequest("ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _studentMarkService.UpdateStudentMarkAsync(studentMarkDto);
            return NoContent();
        }

        // DELETE: api/StudentMark/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentMarkService.DeleteStudentMarkAsync(id);
            return NoContent();
        }
    }
}
