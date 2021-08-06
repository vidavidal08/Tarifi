using AutoMapper;
using MediatR;
using NicosApp.Core.Entidades;
using NicosApp.Core.Excepciones;
using NicosApp.Core.Interfaces.Repositorios;
using System.Threading;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaId
{
    public class GetFraccionArancelariaIdQueryHandler : IRequestHandler<GetFraccionArancelariaIdQuery, GetFraccionArancelariaFiltroIdDto>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFraccionArancelariaRepositorio _fraccionArancelariaRepositorio;
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        public GetFraccionArancelariaIdQueryHandler(IFraccionArancelariaRepositorio fraccionArancelariaRepositorio,
                                      IMapper mapper)
        {
            _fraccionArancelariaRepositorio = fraccionArancelariaRepositorio;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetFraccionArancelariaFiltroIdDto> Handle(GetFraccionArancelariaIdQuery request, CancellationToken cancellationToken)
        {
            var fraccion = await _fraccionArancelariaRepositorio.getIdWithNicoSub(request.Id);
            if (fraccion == null)
            {
                string mensaje = "Fracción no encontrado";
                throw new NotFoundExeption(mensaje);
            }
            var fraccionArancelariasVm = _mapper.Map<FraccionArancelaria, GetFraccionArancelariaFiltroIdDto>(fraccion);

            return fraccionArancelariasVm;
        }
    }
}
