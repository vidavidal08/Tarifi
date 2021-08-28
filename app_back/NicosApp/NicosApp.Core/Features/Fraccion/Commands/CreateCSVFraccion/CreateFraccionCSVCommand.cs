﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccion
{
    public class CreateFraccionCSVCommand : INotification
    {
        /// <summary>
        /// 
        /// </summary>  
        public IFormFile ArchivoCSV { get; set; }
    }
}