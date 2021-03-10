using NicosApp.Core.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.Core.Interfaces.Repositorios.Base
{
    public interface IRepository<T> where T : BaseEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Add(T entity);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(Guid id);
    }
}
