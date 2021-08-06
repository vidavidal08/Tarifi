using NicosApp.Core.Entidades;
using System.Threading.Tasks;

namespace NicosApp.Core.Interfaces.Notificacion.Email
{
    public interface IEmailNotification
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <returns></returns>
        Task Send(EmailMessage emailMessage);
    }
}
