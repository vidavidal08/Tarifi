using Microsoft.EntityFrameworkCore;
using NicosApp.Core.Common;
using NicosApp.Core.Interfaces.Repositorios.Base;
using NicosApp.Infraestructura.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.Infraestructura.Repositorios.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity<Guid>
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly NicosAppContext _nicosAppContext;




        /// <summary>
        /// 
        /// </summary>
        protected DbSet<T> _entities;




        public BaseRepository(NicosAppContext nicosAppContext)
        {
            _nicosAppContext = nicosAppContext;
            _entities = nicosAppContext.Set<T>();

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
            _nicosAppContext.Entry<T>(entity).State = EntityState.Added;
            await _nicosAppContext.SaveChangesAsync();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {

         
            return _entities.AsQueryable();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);

            _nicosAppContext.Entry<T>(entity).State = EntityState.Deleted;
            await _nicosAppContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(Guid id)
        {
            return await _entities.FindAsync(id);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(T entity)
        {
            _nicosAppContext.Entry<T>(entity).State = EntityState.Modified;
            _nicosAppContext.Update(entity);
        }




    }
}
