using MediatR;
using NicosApp.Core.Entidades;
using NicosApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Fraccion.Querys.GetNicoList
{
    public class GetFraccionArancelariaListQuery : IRequest<List<FraccionArancelariaDto>>
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
