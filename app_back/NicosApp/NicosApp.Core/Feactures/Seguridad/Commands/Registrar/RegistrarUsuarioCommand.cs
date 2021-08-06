using MediatR;
using NicosApp.Core.Models;

namespace NicosApp.Core.Feactures.Seguridad.Commands.Registrar
{
    public class RegistrarUsuarioCommand :  IRequest<Result>
    {   
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
