using MediatR;
using System.Collections.Generic;

namespace NicosApp.Core.Features.Fraccion.Querys.GetNicoList
{
    public class GetFraccionArancelariaListQuery : IRequest<List<FraccionArancelariaDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
