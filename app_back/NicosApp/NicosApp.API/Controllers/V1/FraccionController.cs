using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaDetail;
using NicosApp.Core.Feactures.Fraccion.Querys.GetNicoList;
using System.Collections.Generic;
using System.Threading.Tasks;
using NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccion;
using System;
using NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaId;
using NicosApp.Core.Models;
using NicosApp.Core.Entidades;
using Microsoft.AspNetCore.Authorization;

/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.API.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [RequireHttps]
    [ApiVersion("1.0")]
    public class FraccionController : MiControllerBase
    {
       
        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FraccionArancelariaDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetFraccionArancelariaListQuery()));
        }




        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<FraccionArancelariaDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetFraccionArancelariaIdQuery() { Id = id}));
        }



        [HttpGet("{idFraccion}/{id}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<FraccionArancelariaDto>> Get(Guid idFraccion, Guid id)
        {
            return Ok(await Mediator.Send(new GetFraccionArancelariaIdQuery() { Id = id }));
        }





        [HttpGet("filtro")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetFraccionArancelariaFiltroDto>> Get(GetFraccionArancelariaFiltro parametros)
        {
            return Ok(await Mediator.Send(parametros));
        }





        [HttpPost("cargarArancelesCSV")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExportEvents([FromForm] CreateFraccionCSVCommand data)
        {

            await Mediator.Publish(data);
            return NoContent();
        }






    }
}
