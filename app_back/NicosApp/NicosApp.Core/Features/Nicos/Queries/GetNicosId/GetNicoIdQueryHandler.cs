using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NicosApp.Core.Features.Nicos.Queries.GetNicosId
{
    public class GetNicoIdQueryHandler : IRequestHandler<GetNicoIdQuery, GetNicoIdDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GetNicoIdDto> Handle(GetNicoIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
