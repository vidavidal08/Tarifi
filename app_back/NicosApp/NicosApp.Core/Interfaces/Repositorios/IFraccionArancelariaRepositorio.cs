using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NicosApp.Core.Interfaces.Repositorios
{
    public interface IFraccionArancelariaRepositorio : IRepository<FraccionArancelaria>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FraccionArancelaTIGIE"></param>
        /// <returns></returns>
        Task<FraccionArancelaria> getAllWhereFraccionArancelaTIGIE(string FraccionArancelaTIGIE);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<FraccionArancelaria>> getAllWithNicoSub();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="claveFraccion"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        Task<List<FraccionArancelaria>> getAllFiltro(string claveFraccion, string descripcion);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FraccionArancelaria> getIdWithNicoSub(Guid id);
    }
}
