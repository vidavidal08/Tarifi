using MediatR;
using System;

namespace NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaId
{
    public class GetFraccionArancelariaIdQuery : IRequest<GetFraccionArancelariaFiltroIdDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
    }
}
