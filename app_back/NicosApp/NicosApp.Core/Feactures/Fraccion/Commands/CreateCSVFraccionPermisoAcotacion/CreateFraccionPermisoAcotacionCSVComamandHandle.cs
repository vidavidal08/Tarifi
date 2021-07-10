using AutoMapper;
using MediatR;
using NicosApp.Core.Entidades;
using NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccion;
using NicosApp.Core.Interfaces.Files;
using NicosApp.Core.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion
{
    public class CreateFraccionPermisoAcotacionCSVComamandHandle : IRequestHandler<CreateFraccionPermisoAcotacionCSVCommand, List<FraccionPermisoAcotacionCSV>>
    {


        /// <summary>
        /// 
        /// </summary>
        private readonly IFraccionArancelariaRepositorio _fraccionArancelariaRepositorio;

        /// <summary>
        /// 
        /// </summary>
        private readonly IPermisoFraccionRepositorio _permisoFraccionRepositorio;




        /// <summary>
        /// 
        /// </summary>
        private readonly ICsvFraccionFileBuilder _csvFileBuilder;


        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;





        public CreateFraccionPermisoAcotacionCSVComamandHandle(IFraccionArancelariaRepositorio fraccionArancelariaRepositorio,
                                          IPermisoFraccionRepositorio permisoFraccionRepositorio,
                                           ICsvFraccionFileBuilder csvFileBuilder,
                                           IMapper mapper)
        {
            _fraccionArancelariaRepositorio = fraccionArancelariaRepositorio;
            _permisoFraccionRepositorio = permisoFraccionRepositorio;
            _csvFileBuilder = csvFileBuilder;
            _mapper = mapper;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async  Task<List<FraccionPermisoAcotacionCSV>> Handle(CreateFraccionPermisoAcotacionCSVCommand notification, CancellationToken cancellationToken)
        {

            List<FraccionPermisoAcotacionCSV> nuevaListaAgrupada = new List<FraccionPermisoAcotacionCSV>();
            var listaPermisosNoAgregados = new List<FraccionPermisoAcotacionCSV>();


            var csv = notification.ArchivoCSV;

            using (var ms = new MemoryStream())
            {

                await csv.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

            }


            var permisoFraccionDto = _csvFileBuilder.ReadCsvFilePermisoAcotacionToEmployeeModel(csv.OpenReadStream());


            if (permisoFraccionDto != null)
            {

                int conteo = 0;


                

                foreach (var permiso in permisoFraccionDto)
                {
                    try
                    {

        

                        var clave = permiso.ClaveFraccion.Trim();
                        var result = await _fraccionArancelariaRepositorio.getAllWhereFraccionArancelaTIGIE(clave);


                        if (result != null)
                        {
                            var permisoFraccion = new PermisoFraccion()
                            {
                                Id = Guid.NewGuid(),
                                Acotacion = permiso.Acotacion,
                                Permiso = permiso.Perniso,
                                IdFraccionArancelaria = result.Id

                            };


                            await _permisoFraccionRepositorio.Add(permisoFraccion);

                        }
                        else
                        {
                            listaPermisosNoAgregados.Add(permiso);
                        }


                    }
                    catch (Exception ex)
                    {
                        string mensaje = $"{permiso.ClaveFraccion} error en la siguiente clave con el permiso {permiso.Perniso}" +
                            $" y acotación {permiso.Acotacion} número {conteo} mensaje excepcion {ex.Message}";

                        //throw new Exception(mensaje);
                    }

                    conteo += 1;
                }
            }

            return listaPermisosNoAgregados;


        }
    }
}
