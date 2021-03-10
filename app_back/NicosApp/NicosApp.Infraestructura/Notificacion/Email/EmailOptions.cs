using NicosApp.Core.Models;
using NicosApp.Infraestructura.Notificacion.Email.SendGrid;
using NicosApp.Infraestructura.Notificacion.Email.SmtpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Infraestructura.Notificacion.Email
{
    public class EmailOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Provider { get; set; }


        public SmtpClientOptions SmtpClient { get; set; }


        public SendGridOptions SendGrid { get; set; }



        public bool UsedSmtpClient()
        {
            return Provider == "SmtpClient";
        }


        public bool UsedSendGridClient()
        {
            return Provider == "SendGrid";
        }
    }
}
