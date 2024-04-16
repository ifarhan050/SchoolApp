using Azure;
using DemoAttendenceFeature.Dtos.Admission;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.ExampleResponse;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoAttendenceFeature.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id:Guid}", Name = "GetStudent")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetResponseStudentDto),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseStudentDto>> GetStudent(Guid id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound(new { message = "Student Not Found" });
                }
                return Ok(student);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
            
        }


        [HttpPost]
        [ProducesResponseType(typeof(GetResponseStudentDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseStudentDto>> CreateStudent([FromForm]AddRequestStudentdto studentDto)
        {
            try
            {
                var student = await _studentService.CreateStudent(studentDto);
                if (student == null)
                {
                    return BadRequest(new { message = "Failed to Create Student" });
                }
                return Ok(student);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new {message= ex.Message });
            }

        }


        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<GetResponseStudentDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseStudentDto>> GetStudents()
        {

            try
            {
                var students = await _studentService.GetAllStudents();
                if (students == null)
                {
                    return NotFound(new { message = "No Student Found" });
                }
                return Ok(students);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{studentId:Guid}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<string>> DeleteStudent(Guid studentId)
        {
            var isDeleted = await _studentService.DeleteStudent(studentId);
            if (!isDeleted)
            {
                return NotFound(new { message = "Student Not Found" });
            }
            return Ok(new { studentid=studentId} );
        }

        [HttpPut("{studentId:Guid}")]
        [ProducesResponseType(typeof(GetResponseStudentDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseStudentDto>> UpdateStudent(Guid studentId, [FromForm] AddRequestStudentdto studentDto)
        {
            var student = await _studentService.UpdateStudent(studentId,studentDto);
            if (student==null)
            {
                return NotFound(new { message = "Student Not Found" });
            }
            return Ok(student);
        }
    }
}
