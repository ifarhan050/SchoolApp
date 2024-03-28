using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoAttendenceFeature.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ReportingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("{rollnumber:int}")]
        [Consumes("application/pdf")]
        public async Task<IActionResult> StudentInfoReport(int rollnumber)
        {
            string ip = _configuration["Reporting:ip"];

            byte[] result;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://" + ip + "/api/StudentReport?&RollNo=" + rollnumber))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var person = JsonConvert.DeserializeObject(apiResponse);
                    result = Convert.FromBase64String((string)person);
                }
            }
            return File(result, "application/pdf", "StudentReport.pdf");

            // remove output.pdf if you need to open in new tab, add it for direct download
        }
    }
}
