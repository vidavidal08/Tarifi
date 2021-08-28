using MediatR;
using NicosApp.Core.Enums;
using NicosApp.Core.Models;

namespace NicosApp.Core.Features.Seguridad.Commands.Registrar
{
    public class RegistrarUsuarioCommand :  IRequest<Result>
    {   
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        /// <summary>
        /// Enum:
        /// 
        /// TESTING
        /// PLAY_STORE
        /// </summary>
        public TipoActivacion Cliente { get; set; } = TipoActivacion.PLAY_STORE;



    }
}
