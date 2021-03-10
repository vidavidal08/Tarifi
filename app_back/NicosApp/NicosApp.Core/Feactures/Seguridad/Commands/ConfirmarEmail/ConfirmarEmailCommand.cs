using MediatR;
using NicosApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Seguridad.Commands.ConfirmarEmail
{
    public class ConfirmarEmailCommand :   IRequest<Result>
    {
        public string userId { get; set; }

        public string token { get; set; }
    }
}
