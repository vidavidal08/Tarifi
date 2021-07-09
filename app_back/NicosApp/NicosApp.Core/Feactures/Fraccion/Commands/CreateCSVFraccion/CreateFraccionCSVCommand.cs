using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccion
{
    public class CreateFraccionCSVCommand : INotification
    {
        /// <summary>
        /// 
        /// </summary>  
        public IFormFile ArchivoCSV { get; set; }
    }
}
