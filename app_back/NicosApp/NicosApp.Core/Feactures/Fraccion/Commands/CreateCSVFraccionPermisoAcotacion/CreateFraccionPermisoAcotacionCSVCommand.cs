using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion
{
   public  class CreateFraccionPermisoAcotacionCSVCommand : IRequest<List<FraccionPermisoAcotacionCSV>>
    {
        /// <summary>
        /// 
        /// </summary>  
        public IFormFile ArchivoCSV { get; set; }
    }
}
