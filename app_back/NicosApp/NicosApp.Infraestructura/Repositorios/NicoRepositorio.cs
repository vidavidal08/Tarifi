using Microsoft.EntityFrameworkCore;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Infraestructura.Data;
using NicosApp.Infraestructura.Repositorios.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Nico> getAllWhereIdFraccionAndId(Guid idFraccion, Guid id)
        {
            var nico = await _nicosAppContext.Nicos
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return nico;
        }
    }
}
