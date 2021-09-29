using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicosApp.Core.Features.Nicos.Commands.CreateCSVNicos;
using System.Threading.Tasks;

namespace NicosApp.API.Controllers
{
    
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
    }
}
