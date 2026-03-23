using Microsoft.AspNetCore.Identity.UI.Services;
using Resend;

namespace mvctodolist.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IResend _resend;
        public EmailSender(IResend resend)
        {
            _resend = resend;
        }
            public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new EmailMessage();
            message.From = "onboarding@resend.dev";
            message.To.Add(email);
            message.Subject = subject;
            message.HtmlBody = htmlMessage;

            await _resend.EmailSendAsync(message);
        }
     
    }
}