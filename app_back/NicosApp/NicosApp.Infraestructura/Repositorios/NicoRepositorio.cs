using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Infraestructura.Data;
using NicosApp.Infraestructura.Repositorios.Base;

namespace NicosApp.Infraestructura.Repositorios
{
    public class NicoRepositorio : BaseRepository<Nico>, INicoRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        private NicosAppContext _nicosAppContext;



      

        public NicoRepositorio(NicosAppContext nicosAppContext) : base(nicosAppContext)
        {
            _nicosAppContext = nicosAppContext;
        }





    }
}
