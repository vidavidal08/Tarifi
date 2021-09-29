using AutoMapper;
using MediatR;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Files;
using NicosApp.Core.Interfaces.Repositorios;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// Autor: Magdiel Efrain Palacios Rivera
/// Fecha: 28-09-2021
/// </summary>

namespace NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccion
{
    public class CreateFraccionCSVComamandHandle : INotificationHandler<CreateFraccionCSVCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFraccionArancelariaRepositorio _fraccionArancelariaRepositorio;
        /// <summary>
        /// 
        /// </summary>
        private readonly ICsvFraccionFileBuilder _csvFileBuilder;
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        public CreateFraccionCSVComamandHandle(IFraccionArancelariaRepositorio fraccionArancelariaRepositorio,
                                           ICsvFraccionFileBuilder csvFileBuilder,
                                           IMapper mapper)
        {
            _fraccionArancelariaRepositorio = fraccionArancelariaRepositorio;
            _csvFileBuilder = csvFileBuilder;
            _mapper = mapper;
        }



        /// <summary>
        /// Permite cargar el archivo en CSV y mandarlos a la BD.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateFraccionCSVCommand notification, CancellationToken cancellationToken)
        {
            var csv = notification.ArchivoCSV;

            using (var ms = new MemoryStream())
            {

                await csv.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

            }
            var fraccionDto = _csvFileBuilder.ReadCsvFileToEmployeeModel(csv.OpenReadStream());
            if (fraccionDto != null)
            {

                foreach (var fraccion in fraccionDto)
                {

                    var entity = _mapper.Map<FraccionCSV, FraccionArancelaria>(fraccion);

                    var clave = entity.ClaveFraccion;
                    var result = await _fraccionArancelariaRepositorio.getAllWhereFraccionArancelaTIGIE(clave);


                    if (result != null)
                    {
                        await _fraccionArancelariaRepositorio.Delete(result.Id);
                    }


                    entity.Id = Guid.NewGuid();

                    await _fraccionArancelariaRepositorio.Add(entity);

                }
            }
        }
    }
}
