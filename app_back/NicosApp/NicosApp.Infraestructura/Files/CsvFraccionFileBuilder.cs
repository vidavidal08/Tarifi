using CsvHelper;
using NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccion;
using NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion;
using NicosApp.Core.Interfaces.Files;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion.FraccionPermisoAcotacionCSV;

namespace NicosApp.Infraestructura.Files
{
    public class CsvFraccionFileBuilder : ICsvFraccionFileBuilder
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public List<FraccionCSV> ReadCsvFileToEmployeeModel(Stream stream)
        {

            List<FraccionCSV> nicoDtos = null;

            if (stream != null)
            {

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<FraccionCSVMap>();
                        nicoDtos = csv.GetRecords<FraccionCSV>().ToList();



                    }

                    reader.Dispose();
                }
            }

            return nicoDtos;
        } 



        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public IEnumerable<FraccionPermisoAcotacionCSV> ReadCsvFilePermisoAcotacionToEmployeeModel(Stream stream)
        {

            List<FraccionPermisoAcotacionCSV> nicoDtos = null;

            if (stream != null)
            {

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<FraccionPernisoAcotacionCSVMap>();
                        nicoDtos = csv.GetRecords<FraccionPermisoAcotacionCSV>().ToList();



                    }

                    reader.Dispose();
                }
            }

            return nicoDtos;
        }
    }
}
