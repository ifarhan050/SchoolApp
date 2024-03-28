using DemoAttendenceFeature.Dtos.Admission;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAttendenceFeature.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly AdmissionService _admissionStudentService;

        public AdmissionController(AdmissionService admissionStudentService)
        {
            _admissionStudentService = admissionStudentService;
        }

        [HttpPost]
        public async Task<ActionResult<GetResponseStudentDto>> CreateApplicant(AddRequestStudentdto requestDto)
        {
            try
            {

                var studentDto = await _admissionStudentService.CreateStudentApplication(requestDto);
                if (studentDto == null)
                {
                    return BadRequest(new { message = "Failed to Apply" });
                }
                return Ok(studentDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
            
        }

        [HttpPost("{studentId:Guid}")]
        public async Task<ActionResult<GetResponseStudentAdmissionDto>> RegisterApplication(Guid studentId)
        {
            var admissionDto = await _admissionStudentService.RegisterApplication(studentId);
            if (admissionDto==null)
            {
                return NotFound(new { message = "Application Not Found" });
            }
            return Ok(admissionDto);
        }
    }
}
