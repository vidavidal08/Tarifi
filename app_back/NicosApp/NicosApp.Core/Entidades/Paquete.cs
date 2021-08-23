using NicosApp.Core.Common;
using System;

namespace NicosApp.Core.Entidades
{
    public class Paquete: BaseEntity<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
