using NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccion;
using NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Interfaces.Files
{
    public interface ICsvFraccionFileBuilder : ICsvFileBuilder<FraccionCSV>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        IEnumerable<FraccionPermisoAcotacionCSV> ReadCsvFilePermisoAcotacionToEmployeeModel(Stream stream);
    }
}
