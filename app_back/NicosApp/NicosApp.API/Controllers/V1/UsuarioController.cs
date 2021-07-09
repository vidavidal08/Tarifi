using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicosApp.Core.Feactures.Seguridad.Commands.ConfirmarEmail;
using NicosApp.Core.Feactures.Seguridad.Commands.Login;
using NicosApp.Core.Feactures.Seguridad.Commands.Registrar;
using NicosApp.Core.Models;
using System.Threading.Tasks;

namespace NicosApp.API.Controllers
{
    [AllowAnonymous]
    [RequireHttps]
    [ApiVersion("1.0")]
    public class UsuarioController : MiControllerBase
    {


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<ActionResult<TokenDto>> Login(LoginUsuarioCommand usuario)
        {
            return await Mediator.Send(usuario);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [HttpPost("registrar")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Result>> Registrar(RegistrarUsuarioCommand registrarUsuarioCommand)
        {
            return await Mediator.Send(registrarUsuarioCommand);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [HttpGet("confirmarEmail")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Result>> ConfirmarEmail(string userId, string token)
        {

            return await Mediator.Send(new ConfirmarEmailCommand() { userId = userId, token = token});

        }




    }
}
