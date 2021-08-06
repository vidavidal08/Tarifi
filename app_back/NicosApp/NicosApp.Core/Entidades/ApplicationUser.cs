﻿using Microsoft.AspNetCore.Identity;

namespace NicosApp.Core.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
