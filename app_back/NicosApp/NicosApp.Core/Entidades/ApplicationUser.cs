using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace NicosApp.Core.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public ICollection<Suscripcion> Suscripciones { get; set; }
    }
}
