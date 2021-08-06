using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion
{
    public  class CreateFraccionPermisoAcotacionCSVCommand : IRequest<List<FraccionPermisoAcotacionCSV>>
    {
        /// <summary>
        /// 
        /// </summary>  
        public IFormFile ArchivoCSV { get; set; }
    }
}
