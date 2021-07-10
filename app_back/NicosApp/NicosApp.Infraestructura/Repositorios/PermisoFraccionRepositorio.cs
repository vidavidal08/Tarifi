using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Infraestructura.Data;
using NicosApp.Infraestructura.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Infraestructura.Repositorios
{
    public class PermisoFraccionRepositorio : BaseRepository<PermisoFraccion>, IPermisoFraccionRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        private NicosAppContext _nicosAppContext;



        public PermisoFraccionRepositorio(NicosAppContext nicosAppContext) : base(nicosAppContext)
        {
            _nicosAppContext = nicosAppContext;
        }



    }
}
