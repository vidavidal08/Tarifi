using MediatR;
using System.Collections.Generic;

namespace NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaDetail
{
    public class GetFraccionArancelariaFiltro : IRequest<List<GetFraccionArancelariaFiltroDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public string ClaveArancelaria { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; }
    }
}
