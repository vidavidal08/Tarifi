﻿using System.Collections.Generic;
using System.IO;

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
