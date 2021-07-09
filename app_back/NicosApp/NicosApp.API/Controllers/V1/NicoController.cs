using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos;
using System.Threading.Tasks;

namespace NicosApp.API.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [RequireHttps]
    [ApiVersion("1.0")]
    public class NicoController  : MiControllerBase
    {


        [HttpPost("cargarNicoCSV")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExportEvents([FromForm] CreateNicosCSVCommand data)
        {
            Url.Action();

            await Mediator.Publish(data);
            return NoContent();
        }



        //[HttpGet("{idFraccion}")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<FraccionArancelariaDto>> Get(Guid ididFraccion)
        //{
        //    return Ok(await Mediator.Send(new GetFraccionArancelariaIdQuery() { Id = id }));
        //}


    }
}
