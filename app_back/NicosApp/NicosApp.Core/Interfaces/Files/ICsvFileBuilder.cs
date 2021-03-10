using NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Interfaces.Files
{
    public interface ICsvFileBuilder<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        List<T> ReadCsvFileToEmployeeModel(Stream stream);

    }
}
