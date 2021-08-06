using MailKit.Security;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Notificacion.Email;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Text;
using NicosApp.Infraestructura.Notificacion.Email.SmtpClient;

namespace NicosApp.Infraestructura.Notificacion
{
    public class SendEmailSmtpNotification : IEmailNotification
    {
        private readonly SmtpClientOptions _options;
        public SendEmailSmtpNotification(SmtpClientOptions options)
        {
            _options = options;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <returns></returns>
        public async Task Send(EmailMessage emailMessage)
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("magefra9@hotmail.com"));
            email.To.Add(MailboxAddress.Parse(emailMessage.Email));
            email.Subject = emailMessage.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body };

            // send email
            int port = _options.Port == null ? 587 : _options.Port.Value;
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_options.Host, port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_options.UserName, _options.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
