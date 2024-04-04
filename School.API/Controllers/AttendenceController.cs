using DemoAttendenceFeature.Dtos.Attendence;
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
    public class AttendenceController : ControllerBase
    {
        private readonly AttendenceService _attendenceService;
        private readonly EmailService _emailService;

        public AttendenceController(AttendenceService attendenceService, EmailService emailService)
        {
            _attendenceService = attendenceService;
            _emailService = emailService;
        }

        [HttpPost("{studentId:Guid}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetSingleAttendenceResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetSingleAttendenceResponseDto>> AddAttendence(Guid studentId)
        {
            try
            {
                var attendence = await _attendenceService.AddAttendence(studentId);
                if (attendence == null)
                {
                    return BadRequest(new { message = "Failed To Add Attendence" });
                }
                var isSent=await _emailService.AttendenceAlertEmail(studentId);
                return Ok(attendence);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetSingleAttendenceResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetSingleAttendenceResponseDto>> GetAttendence([FromBody] GetRequestSingleAttendeceDto requestDto)
        {
            try
            {
                var attendence = await _attendenceService.GetSingleAttendence(requestDto.studentId, requestDto.DateTime);
                if (attendence == null)
                {
                    return NotFound(new { message = "Attendence Not Found" });
                }
                return Ok(attendence);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{studentId:Guid}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetMultipleAttendenceResponsedto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetMultipleAttendenceResponsedto>> GetAllAttendece(Guid studentId)
        {
            try
            {
                var attendences = await _attendenceService.GetAllAttendence(studentId);
                if (attendences == null)
                {
                    return NotFound(new { message = "Attendence Not Found" });
                }
                return Ok(attendences);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
