using CsvHelper;
using NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos;
using NicosApp.Core.Interfaces.Files;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Infraestructura.Files
{
    public class CsvNicosFileBuilder : ICsvNicosFileBuilder
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public List<NicoCSV> ReadCsvFileToEmployeeModel(Stream stream)
        {

            List<NicoCSV> nicoDtos = null;

            if (stream != null)
            {

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<NicoCSVMap>();
                        nicoDtos = csv.GetRecords<NicoCSV>().ToList();



                    }

                    reader.Dispose();
                }
            }

            return nicoDtos;


        }
    }
}
