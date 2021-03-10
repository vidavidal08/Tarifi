using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Notificacion.Email;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Infraestructura.Notificacion.Email.SendGrid
{
    public class SendGridEmailNotification : IEmailNotification
    {
        private readonly SendGridOptions _options;


        public SendGridEmailNotification(SendGridOptions options)
        {
            _options = options;
        }



        public async Task Send(EmailMessage emailMessage)
        {
            var client = new SendGridClient(_options.ApiKey);

            var subject = emailMessage.Subject;
           
           

            var from = new EmailAddress
            {
                Email = _options.FromAddress,
                Name = "magefra9"
            };

            var to = new EmailAddress(emailMessage.Email, "magdiel");

            var plainContent = "Hello";
            var emailBody = emailMessage.Body;

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, plainContent, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

          
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                bool isok = true;
            }
        }
    }
}
