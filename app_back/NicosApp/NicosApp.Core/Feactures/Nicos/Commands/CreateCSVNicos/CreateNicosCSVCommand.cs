using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 22-02-2021
/// </summary>
namespace NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos
{
    public class CreateNicosCSVCommand : INotification
    {
       
        /// <summary>
        /// 
        /// </summary>  
        public IFormFile ArchivoCSV { get; set; }

    }
}
