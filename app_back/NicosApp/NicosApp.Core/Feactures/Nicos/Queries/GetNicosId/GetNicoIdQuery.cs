using MediatR;
using System;

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
