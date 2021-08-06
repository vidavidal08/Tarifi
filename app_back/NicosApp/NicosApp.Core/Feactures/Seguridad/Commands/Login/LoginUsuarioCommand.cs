﻿using MediatR;

namespace NicosApp.Core.Feactures.Seguridad.Commands.Login
{
    public class LoginUsuarioCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
