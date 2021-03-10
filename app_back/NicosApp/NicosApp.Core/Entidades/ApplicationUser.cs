using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }

        public string Apellidos { get; set; }
    }
}
