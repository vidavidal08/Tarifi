using AutoMapper;
using MediatR;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Identity;
using NicosApp.Core.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NicosApp.Core.Features.Fraccion.Queries.GetFraccionArancelariaDetail
{
    public class GetFraccionArancelariaFiltroHandle : IRequestHandler<GetFraccionArancelariaFiltro, List<GetFraccionArancelariaFiltroDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFraccionArancelariaRepositorio _fraccionArancelariaRepositorio;
        /// <summary>
        /// 
        /// </summary>
        private readonly INicoRepositorio _nicoRepositorio;
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;


        /// <summary>
        /// 
        /// </summary>
        private readonly ICurrentUserService _currentUserService;



        public GetFraccionArancelariaFiltroHandle(IFraccionArancelariaRepositorio fraccionArancelariaRepositorio,
                                       INicoRepositorio nicoRepositorio,
                                       IMapper mapper,
                                       ICurrentUserService currentUserService)
        {
            _fraccionArancelariaRepositorio = fraccionArancelariaRepositorio;
            _nicoRepositorio = nicoRepositorio;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetFraccionArancelariaFiltroDto>> Handle(GetFraccionArancelariaFiltro request, CancellationToken cancellationToken)
        {

            var email = _currentUserService.UserId;



            var fraccionArancelaria = await _fraccionArancelariaRepositorio.getAllFiltro(request.ClaveArancelaria, request.Descripcion);
            var fraccionArancelariaDto = _mapper.Map<List<FraccionArancelaria>, List<GetFraccionArancelariaFiltroDto>>(fraccionArancelaria);
            return fraccionArancelariaDto;
        }
    }
}
