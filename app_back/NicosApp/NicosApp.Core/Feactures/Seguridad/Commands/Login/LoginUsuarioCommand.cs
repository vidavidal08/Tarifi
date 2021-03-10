using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Seguridad.Commands.Login
{
    public class LoginUsuarioCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
