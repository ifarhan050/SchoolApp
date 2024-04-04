using DemoAttendenceFeature.Helper.Interface;
using DemoAttendenceFeature.Setting_Models;
using Microsoft.Extensions.Options;
using DemoAttendenceFeature.Model;
using Microsoft.OpenApi.Models;
using RestSharp;
using System.Net;
using RestSharp.Authenticators;

namespace DemoAttendenceFeature.Helper
{
    public class Email : IEmail
    {
        private EmailSettings _emailSettings;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Email> _logger;
        public Email(ILogger<Email> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _emailSettings = new EmailSettings();
            _emailSettings.ApiKey =_configuration["Mailgun:ApiKey"];
            _emailSettings.From = _configuration["Mailgun:From"];
            _emailSettings.Domaim = _configuration["Mailgun:Domain"];
            _logger = logger;
        }

        public async Task<bool> SendEmailMultipleRecipient(MultipleEmailModel email)
        {
            RestClient client = new RestClient("https://api.mailgun.net/v3");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", _emailSettings.Domaim, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", _emailSettings.From);

            foreach (var to in email.Tos)
            {
                request.AddParameter("to", to);
            }
            request.AddParameter("subject", email.Subject);
            request.AddParameter("html", email.Body);
            request.Authenticator = new HttpBasicAuthenticator("api", _emailSettings.ApiKey);
            var response=await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SendEmailSingleRecipient(SingleEmailModel email)
        {
            

            RestClient client = new RestClient("https://api.mailgun.net/v3");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", _emailSettings.Domaim, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", _emailSettings.From);

            
            request.AddParameter("to", email.To);
            request.AddParameter("subject", email.Subject);
            request.AddParameter("html", email.Body);
            request.Method = RestSharp.Method.Post;
            request.Authenticator = new HttpBasicAuthenticator("api", _emailSettings.ApiKey);
            var response = client.Post(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
