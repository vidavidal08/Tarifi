using MediatR;
using System;

namespace NicosApp.Core.Features.Fraccion.Queries.GetFraccionArancelariaId
{
    public class GetFraccionArancelariaIdQuery : IRequest<GetFraccionArancelariaFiltroIdDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
    }
}
