using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace TopfinAPI.EmailSenders
{
    public class EmailSender
    {
        public async Task SendEmail(string subject, string toEmail, string userName, string message, string htmlInput)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("milkocd@gmail.com", "MilkOCD");
            var to = new EmailAddress(toEmail, userName);
            var plainTextContent = message;
            var htmlContent = htmlInput;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
