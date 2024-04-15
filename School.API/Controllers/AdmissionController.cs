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
        private readonly RegistrationEmailService _emailService;

        public AdmissionController(AdmissionService admissionStudentService, RegistrationEmailService emailService)
        {
            _admissionStudentService = admissionStudentService;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult<GetResponseStudentDto>> CreateApplicant([FromForm]AddRequestStudentdto requestDto)
        {
            try
            {

                var studentDto = await _admissionStudentService.CreateStudentApplication(requestDto);
                if (studentDto == null)
                {
                    return BadRequest(new { message = "Failed to Apply" });
                }
                var isSent = await _emailService.RegistrationAlertEmail(studentDto.Id);
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
