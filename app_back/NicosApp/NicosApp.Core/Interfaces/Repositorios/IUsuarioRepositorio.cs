using Microsoft.AspNetCore.Identity;
using NicosApp.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> isWhereEmailAsync(string email);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IdentityResult> createUserAsync(ApplicationUser usuario, string password);
    }
}
