using AutoMapper;
using NicosApp.Core.Entidades;
using NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos;
using NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaDetail;
using NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaList;
using NicosApp.Core.Feactures.Fraccion.Querys.GetNicoList;
using NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccion;
using NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaId;

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


            CreateMap<FraccionArancelaria, GetFraccionArancelariaFiltroDto>()
                 .ReverseMap();



            CreateMap<FraccionArancelaria, GetFraccionArancelariaFiltroIdDto>()
                 .ReverseMap();





            CreateMap<Nico, NicoDto>()
                .ReverseMap();



            CreateMap<NicoCSV,Nico>()
                 .ReverseMap();


        }
    }
}
