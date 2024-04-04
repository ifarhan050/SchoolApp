using DemoAttendenceFeature.Helper.EmailDynamic_Content;
using DemoAttendenceFeature.Helper.Interface;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Model;
using Microsoft.AspNetCore.Routing.Template;
using System.IO;

namespace DemoAttendenceFeature.Service
{
    public class EmailService
    {
        private readonly IEmail _email;
        private readonly IAttendenceRepository _attendenceRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private string rootPath;
        private bool Active;

        public EmailService(IEmail email, IWebHostEnvironment hostingEnvironment, IAttendenceRepository attendenceRepository, IConfiguration configuration)
        {
            _email = email;
            _hostingEnvironment = hostingEnvironment;
            rootPath = Path.Join(_hostingEnvironment.ContentRootPath, "wwwroot");
            _attendenceRepository = attendenceRepository;
            _configuration = configuration;
            Active =Convert.ToBoolean(_configuration["Mailgun:Active"]);
        }

        public async Task<bool> AttendenceAlertEmail(Guid studentId)
        {

            var attendence = await _attendenceRepository.GetAttenceByDate(studentId, DateTime.Now);
            if (attendence!=null && Active)
            {
                var htmlTemplatePath = Path.Join(rootPath, "EmailTemplates", "AttendenceAlert.html");
                if (System.IO.File.Exists(htmlTemplatePath))
                {
                    var body = "";
                    using (StreamReader _stream_reader = new StreamReader(htmlTemplatePath))
                    {
                        body = _stream_reader.ReadToEnd();
                    }
                    var dynamicContent = AttendenceAlertEmailBody.SingleStudentBody
                        .Replace("{student.Checkin}", attendence.TimeIn.ToString("hh mm tt"))
                        .Replace("{student.Checkout}", attendence.TimeOut?.ToString("hh mm tt") ?? "To Be Checked Out");
                    body=body
                        .Replace("{{Name}}", attendence.Student.Name)
                        .Replace("{{detailitems}}", dynamicContent);
                    var emailmodel = new MultipleEmailModel();
                    emailmodel.Subject = $"SchoolWare Attendance Alert of {attendence.Student.Name} {DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm")}";
                    emailmodel.Body = body;
                    emailmodel.Tos = attendence.Student.Guardians.Select(x => x.Email).ToList();

                    return await _email.SendEmailMultipleRecipient(emailmodel);
                }               
            }
            return false;

        }
    }
}
