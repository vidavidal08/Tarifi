using NicosApp.Core.Entidades;

namespace NicosApp.Core.Interfaces.Identity
{
    public interface IJwtGenerador
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        string crearToken(ApplicationUser usuario);
    }
}
