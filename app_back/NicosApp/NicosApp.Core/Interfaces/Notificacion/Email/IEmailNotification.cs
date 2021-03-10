using NicosApp.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
