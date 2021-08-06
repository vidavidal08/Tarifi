using MediatR;
using NicosApp.Core.Models;

namespace NicosApp.Core.Features.Seguridad.Commands.ConfirmarEmail
{
    public class ConfirmarEmailCommand :   IRequest<Result>
    {
        public string userId { get; set; }
        public string token { get; set; }
    }
}
