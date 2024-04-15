using DemoAttendenceFeature.Dtos.GuardianStudent;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.ExampleResponse;
using DemoAttendenceFeature.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoAttendenceFeature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGuardianController : ControllerBase
    {
        private readonly GuardianStudentService _guardianStudentService;

        public StudentGuardianController(GuardianStudentService guardianStudentService)
        {
            _guardianStudentService = guardianStudentService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetResponseStudentDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseStudentDto>> AssignGuardian(AddRequestGuardianStudentDto requestDto)
        {
            try
            {
                var response = await _guardianStudentService.AddGuardian(requestDto.studentId, requestDto.guardianId);
                if (response == null)
                {
                    return NotFound(new { message = "Failed to Create Student" });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
