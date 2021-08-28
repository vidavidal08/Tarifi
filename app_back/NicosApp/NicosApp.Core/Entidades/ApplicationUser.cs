using Microsoft.AspNetCore.Identity;

namespace NicosApp.Core.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }


        /// <summary>
        /// enum:
        /// - PLAY_STORE
        /// - TESTING
        /// </summary>
        public string Cliente { get; set; }


        /// <summary>
        /// 1 : Activo
        /// 0 : Inactivo
        /// </summary>
        public bool Estatus { get; set; }
    }
}
