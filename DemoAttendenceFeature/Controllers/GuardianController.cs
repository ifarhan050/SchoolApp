using DemoAttendenceFeature.Dtos.Guardian;
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
    public class GuardianController : ControllerBase
    {
        private readonly GuardianService _guardianService;

        public GuardianController(GuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> CreateGuardian(AddRequestGuardianDto requestDto)
        {
            try
            {
                var guardianId = await _guardianService.CreateGuardian(requestDto);
                if (!(guardianId > 0))
                {
                    return BadRequest(new { message = "Failed to Create Guardian" });
                }
                return Ok(new { id = guardianId });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpGet("{id:int}",Name = "GetGuardian")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetResponseGuardianDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseGuardianDto>> GetGuardian(int id)
        {
            try
            {
                var guardian = await _guardianService.GetGuardian(id);
                if (guardian == null)
                {
                    return NotFound(new { message = "Guardian Not Found" });
                }
                return Ok(guardian);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
