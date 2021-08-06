using MediatR;
using Microsoft.AspNetCore.Identity;
using NicosApp.Core.Entidades;
using NicosApp.Core.Excepciones;
using NicosApp.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Seguridad.Commands.ConfirmarEmail
{
    public class ConfirmarEmailCommandHandle : IRequestHandler<ConfirmarEmailCommand, Result>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        public ConfirmarEmailCommandHandle(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result> Handle(ConfirmarEmailCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(request.userId);

            if(user != null)
            {
                IdentityResult result = await _userManager.
                ConfirmEmailAsync(user, request.token);
                if (result.Succeeded)
                {
                    return Result.Success("¡Correo electrónico confirmado correctamente!");
                }
            }
            throw new ApiException("Error en validar el correo");
        }
    }
}
