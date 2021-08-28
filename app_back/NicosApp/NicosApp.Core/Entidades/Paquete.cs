using NicosApp.Core.Common;
using System;
using System.Collections.Generic;

namespace NicosApp.Core.Entidades
{
    public class Paquete: BaseEntity<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Suscripcion> Suscripciones { get; set; }
    }
}
