using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
