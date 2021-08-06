using AutoMapper;
using NicosApp.Core.Dtos;
using NicosApp.Core.Entidades;
using NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccion;
using NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion;
using NicosApp.Core.Features.Fraccion.Queries.GetFraccionArancelariaDetail;
using NicosApp.Core.Features.Fraccion.Queries.GetFraccionArancelariaId;
using NicosApp.Core.Features.Fraccion.Queries.GetFraccionArancelariaList;
using NicosApp.Core.Features.Fraccion.Querys.GetNicoList;
using NicosApp.Core.Features.Nicos.Commands.CreateCSVNicos;

namespace NicosApp.Core.Mappings
{
    public class NicoProfile : Profile
    {
        public NicoProfile()
        {
            CreateMap<FraccionArancelaria, FraccionArancelariaDto>()
                 .ReverseMap();

            CreateMap<FraccionCSV, FraccionArancelaria>()
            .ReverseMap();

            CreateMap<FraccionPermisoAcotacionCSV, FraccionArancelaria>()
              .ReverseMap();

            CreateMap<FraccionPermisoAcotacionCSV, PermisoFraccion>()
             .ReverseMap();

            CreateMap<FraccionArancelaria, GetFraccionArancelariaFiltroDto>()
                 .ReverseMap();

            CreateMap<FraccionArancelaria, GetFraccionArancelariaFiltroIdDto>()
                 .ReverseMap();

            CreateMap<Nico, NicoDto>()
                .ReverseMap();

            CreateMap<PermisoFraccion, PermisoFraccionDto>()
                .ReverseMap();

            CreateMap<NicoCSV, Nico>()
                 .ReverseMap();
        }
    }
}