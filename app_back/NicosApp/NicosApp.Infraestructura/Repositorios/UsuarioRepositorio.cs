using DocumentFormat.OpenXml.Office2016.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        /// <summary>
        /// 
        /// </summary>
        private NicosAppContext _nicosAppContext;


        /// <summary>
        /// 
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;





        public UsuarioRepositorio(NicosAppContext nicosAppContext, UserManager<ApplicationUser> userManager)
        {
            _nicosAppContext = nicosAppContext;
            _userManager = userManager;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IdentityResult> createUserAsync(ApplicationUser usuario, string password)
        {
            IdentityResult resultado = null;
            try
            {
                 resultado = await _userManager.CreateAsync(usuario, password);
            }
            catch (Exception ex)
            {

                throw;
            }
           
            return resultado;

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> isWhereEmailAsync(string email)
        {
            var result = await _nicosAppContext.Users.Where(
                                      x => x.Email == email).AnyAsync();



            return result;

        }




    }
}
