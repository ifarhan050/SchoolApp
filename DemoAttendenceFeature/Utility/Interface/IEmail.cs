using DemoAttendenceFeature.Model;

namespace DemoAttendenceFeature.Helper.Interface
{
    public interface IEmail
    {
        public Task<bool> SendEmailSingleRecipient(SingleEmailModel email);
        public Task<bool> SendEmailMultipleRecipient(MultipleEmailModel email);
    }
}
