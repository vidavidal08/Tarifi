using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NicosApp.Core.Interfaces.Notificacion.Email;
using NicosApp.Infraestructura.Notificacion.Email.SendGrid;
using NicosApp.Infraestructura.Notificacion.Email.SmtpClient;

namespace NicosApp.Infraestructura.Notificacion.Email
{
    public static class EmailNotificationServiceCollectionExtensions
    {



        // <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddSmtpClientEmailNotification(this IServiceCollection services,
                                                                        SmtpClientOptions options)
        {
            services.AddSingleton<IEmailNotification>(new SendEmailSmtpNotification(options));
            return services;
        }



        // <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddSendGridClientEmailNotification(this IServiceCollection services,
                                                                        SendGridOptions options)
        {
            services.AddSingleton<IEmailNotification>(new SendGridEmailNotification(options));
            return services;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddEmailNotification(this IServiceCollection services, IConfiguration configuration)
        {


            var options = new EmailOptions();
            configuration.GetSection("Email").Bind(options);


            if (options.UsedSmtpClient())
            {
                services.AddSmtpClientEmailNotification(options.SmtpClient);
            }


            if (options.UsedSendGridClient())
            {
                services.AddSendGridClientEmailNotification(options.SendGrid);
            }

            return services;
        }
    }
}
