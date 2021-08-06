using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Infraestructura.Data;
using NicosApp.Infraestructura.Repositorios.Base;

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
