using NicosApp.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Interfaces.Identity
{
    public interface IJwtGenerador
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        string crearToken(ApplicationUser usuario);
    }
}
