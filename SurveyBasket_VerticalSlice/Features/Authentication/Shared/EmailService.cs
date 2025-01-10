using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace SurveyBasket_VerticalSlice.Features.Authentication.Shared
{
    public class EmailService : IEmailSender // built in 
    {
        private readonly MailSetting _options;

        public EmailService(IOptions<MailSetting> options)
        {
            _options = options.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage()
            {
                Sender = MailboxAddress.Parse(_options.User),
                Subject = subject
            };

            message.To.Add(MailboxAddress.Parse(email));

            var builer = new BodyBuilder()
            {
                HtmlBody = htmlMessage
            };

            using var stmp = new SmtpClient();
            stmp.Connect(_options.Host, _options.Port, MailKit.Security.SecureSocketOptions.StartTls);
            stmp.Authenticate(_options.User, _options.Pass);
            await stmp.SendAsync(message);
            await stmp.DisconnectAsync(true);
        }
    }
}
