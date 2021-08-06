using NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccion;
using NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion;
using System.Collections.Generic;
using System.IO;

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
