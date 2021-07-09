using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
