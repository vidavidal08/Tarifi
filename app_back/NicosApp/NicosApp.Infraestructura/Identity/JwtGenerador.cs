using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NicosApp.Infraestructura.Identity
{
    public class JwtGenerador : IJwtGenerador
    {
        private readonly IConfiguration _configuration;


        public JwtGenerador(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string crearToken(ApplicationUser usuario)
        {
            var claims = new List<Claim>() {
                   new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));


            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var tokenDesripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMonths(12),
                SigningCredentials = credenciales
            };

            var tokenManejador = new JwtSecurityTokenHandler();

            var token = tokenManejador.CreateToken(tokenDesripcion);

            return tokenManejador.WriteToken(token);

        }
    }
}
