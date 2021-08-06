using AutoMapper;
using MediatR;
using NicosApp.Core.Entidades;
using NicosApp.Core.Feactures.Fraccion.Querys.GetNicoList;
using NicosApp.Core.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.Core.Feactures.Fraccion.Querys
{
    public class GetFraccionArancelariaListQueryHandler : IRequestHandler<GetFraccionArancelariaListQuery, List<FraccionArancelariaDto>>
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
        public GetFraccionArancelariaListQueryHandler(IFraccionArancelariaRepositorio fraccionArancelariaRepositorio,
                                       INicoRepositorio nicoRepositorio,
                                       IMapper mapper)
        {
            _fraccionArancelariaRepositorio = fraccionArancelariaRepositorio;
            _nicoRepositorio = nicoRepositorio;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<FraccionArancelariaDto>> Handle(GetFraccionArancelariaListQuery request, CancellationToken cancellationToken)
        {


            var nicos = await _fraccionArancelariaRepositorio.getAllWithNicoSub();

            var nicoListVm = _mapper.Map<List<FraccionArancelaria>, List<FraccionArancelariaDto>>(nicos);

            return nicoListVm;

        }
    }
}
