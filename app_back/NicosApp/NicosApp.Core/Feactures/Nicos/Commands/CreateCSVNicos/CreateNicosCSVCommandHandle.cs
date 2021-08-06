using AutoMapper;
using MediatR;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Files;
using NicosApp.Core.Interfaces.Repositorios;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 22-02-2021
/// </summary>
namespace NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos
{
    public class CreateNicosCSVCommandHandle : INotificationHandler<CreateNicosCSVCommand>
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
        private readonly ICsvNicosFileBuilder _csvFileBuilder;
        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;
        public CreateNicosCSVCommandHandle(IFraccionArancelariaRepositorio fraccionArancelariaRepositorio,
                                           INicoRepositorio nicoRepositorio,
                                           ICsvNicosFileBuilder csvFileBuilder,
                                           IMapper mapper)
        {
            _fraccionArancelariaRepositorio = fraccionArancelariaRepositorio;
            _nicoRepositorio = nicoRepositorio;
            _csvFileBuilder = csvFileBuilder;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateNicosCSVCommand notification, CancellationToken cancellationToken)
        {
            var csv = notification.ArchivoCSV;
            using (var ms = new MemoryStream())
            {

                await csv.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

                string result = System.Text.Encoding.UTF8.GetString(fileBytes);
            }
            var nidosDto = _csvFileBuilder.ReadCsvFileToEmployeeModel(csv.OpenReadStream());
            if (nidosDto != null)
            {
                //Agrupar por FracciónAranceles
                var gruopuNico = nidosDto
                                 .GroupBy(c => c.FraccionArancelaTIGIE)
                                 .OrderBy(c => c.Key)
                                 .Select(c => new { c.Key, fraccion = c.OrderBy(y => y.FraccionArancelaTIGIE) });

                if (gruopuNico != null)
                {
                    //Leemos todos los Arencelarias agrupadas
                    foreach (var nicokey in gruopuNico)
                    {
                        //Obtenemos la FraccionArancela del csv.
                        string claveFraccion = nicokey.Key;
                        Guid idClave = Guid.Empty;
                        //Verificamos si ya se encuentrá registrado en la BD.
                        if (await _fraccionArancelariaRepositorio.getAllWhereFraccionArancelaTIGIE(claveFraccion) != null)
                        {
                            //Guadarmos la FraccionArancela
                            var entityFraccion = await _fraccionArancelariaRepositorio.getAllWhereFraccionArancelaTIGIE(claveFraccion);
                            idClave = entityFraccion.Id;
                            // .Where(x => products == null || products.Contains(x.ProductID))
                            var nicos = nidosDto.Where(c => c.FraccionArancelaTIGIE == claveFraccion);
                            if (nicos != null)
                            {
                                foreach (var nicoDto in nicos)
                                {
                                    var nico = new Nico
                                    {
                                        Id = Guid.NewGuid(),
                                        Descripcion = nicoDto.Descripcion,
                                        IdFraccionArancelaria = idClave,
                                        ClaveNICO = nicoDto.NICO
                                    };
                                    await _nicoRepositorio.Add(nico);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
