using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Nicos.Queries.GetNicosId
{
    public class GetNicoIdQuery : IRequest<GetNicoIdDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid IdFraccion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
    }
}
