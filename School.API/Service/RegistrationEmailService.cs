using DemoAttendenceFeature.Helper.EmailDynamic_Content;
using DemoAttendenceFeature.Helper.Interface;
using DemoAttendenceFeature.Infrastructure;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Model;
using Microsoft.AspNetCore.Routing.Template;
using System.IO;

namespace DemoAttendenceFeature.Service
{
    public class RegistrationEmailService
    {
        private readonly IEmail _email;
        private readonly IAttendenceRepository _attendenceRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IAdmissionStudentStatusRepository _admissionStudentStatusRepository;
        private readonly IStudentRepository _studentRepository;
        private string rootPath;
        private bool Active;

        public RegistrationEmailService(IEmail email,
            IWebHostEnvironment hostingEnvironment,
            IConfiguration configuration,
            IStudentRepository studentRepository)
        {
            _email = email;
            _hostingEnvironment = hostingEnvironment;
            rootPath = Path.Join(_hostingEnvironment.ContentRootPath, "wwwroot");
            _configuration = configuration;
            _studentRepository = studentRepository;
            Active =Convert.ToBoolean(_configuration["Mailgun:Active"]);
        }

        public async Task<bool> RegistrationAlertEmail(Guid studentId)
        {
            var student = await _studentRepository.GetStudentById(studentId, true);

            if (student.AdmissionStatus.Status =="Pending" && student.AdmissionStatus!=null && Active) 
            {
                var htmlTemplatePath = Path.Join(rootPath, "EmailTemplates", "RegistrationAlert.html");
                if (System.IO.File.Exists(htmlTemplatePath))
                {
                    var body = "";
                    using (StreamReader _stream_reader = new StreamReader(htmlTemplatePath))
                    {
                        body = _stream_reader.ReadToEnd();
                    }
                    //var dynamicContent = AttendenceAlertEmailBody.SingleStudentBody
                    //    .Replace("{student.Checkin}", attendence.TimeIn.ToString("hh mm tt"))
                    //    .Replace("{student.Checkout}", attendence.TimeOut?.ToString("hh mm tt") ?? "To Be Checked Out");
                    body = body
                        .Replace("{{Name}}", student.Name);
                        //.Replace("{{detailitems}}", dynamicContent);
                    var emailmodel = new MultipleEmailModel();
                    emailmodel.Subject = $"Application Recieved for {student.Name}";
                    //emailmodel.Subject = $"SchoolWare Registration Alert of {student.Name} {DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm")}";
                    emailmodel.Body = body;
                    emailmodel.Tos = student.Guardians.Select(x => x.Email).ToList();

                    return await _email.SendEmailMultipleRecipient(emailmodel);
                }               
            }
            return false;

        }
    }
}
