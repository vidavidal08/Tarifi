using Microsoft.EntityFrameworkCore;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Infraestructura.Data;
using NicosApp.Infraestructura.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicosApp.Infraestructura.Repositorios
{
    public class FraccionArancelariaRepositorio : BaseRepository<FraccionArancelaria>, IFraccionArancelariaRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        private NicosAppContext _nicosAppContext;
        public FraccionArancelariaRepositorio(NicosAppContext nicosAppContext) : base(nicosAppContext)
        {
            _nicosAppContext = nicosAppContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FraccionArancelaria> getAllWhereFraccionArancelaTIGIE(string ClaveFraccion)
        {
            var nico = await _nicosAppContext.FraccionArancelarias
                             .Include(x => x.Nicos)
                             .FirstOrDefaultAsync(x => x.ClaveFraccion == ClaveFraccion);
            return nico;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FraccionArancelaria> getAllWhereDescripcion(string descripcion)
        {
            var nico = await _nicosAppContext.FraccionArancelarias.Include(x => x.Nicos).FirstOrDefaultAsync(x => x.Descripcion == descripcion);
            return nico;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<FraccionArancelaria>> getAllFiltro(string claveFraccion,string descripcion)
        {
            var fraccionArancelariaQueryable = _nicosAppContext.FraccionArancelarias.AsQueryable();
            if (!string.IsNullOrWhiteSpace(claveFraccion))
            {
                fraccionArancelariaQueryable = fraccionArancelariaQueryable.Where(x => x.ClaveFraccion.Trim().Contains(claveFraccion));
            }
            if (!string.IsNullOrWhiteSpace(descripcion))
            {
                fraccionArancelariaQueryable = fraccionArancelariaQueryable
                    .Where(x => x.Descripcion.Trim().ToLower().Replace("á", "a").Replace("í", "i").Replace("ó", "o").Contains(descripcion.Replace("á", "a").Replace("í", "i").Replace("ó", "o").Trim().ToLower()));
            }
            fraccionArancelariaQueryable = fraccionArancelariaQueryable.Skip(0).Take(100);
            return await fraccionArancelariaQueryable.Include(x => x.Nicos).Include(x => x.PermisosFraccion).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<FraccionArancelaria>> getAllWithNicoSub()
        {
            var nico = await _nicosAppContext.FraccionArancelarias.Include(x => x.Nicos).Skip(0).Take(100).ToListAsync();
            return nico;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<FraccionArancelaria>> getAllWithNicoSubAndPermisos()
        {
            var nico = await _nicosAppContext
                .FraccionArancelarias
                .Include(x => x.Nicos)
                .Include(x => x.PermisosFraccion)
                .ToListAsync();
            return nico;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FraccionArancelaria> getIdWithNicoSub(Guid id)
        {
            var nico = await _nicosAppContext.FraccionArancelarias.Include(x => x.Nicos)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return nico;
        }
    }
}
