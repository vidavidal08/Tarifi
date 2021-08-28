using NicosApp.Core.Common;
using System;

namespace NicosApp.Core.Entidades
{
    public class TipoSuscripcion: BaseEntity<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int DiasVigencia { get; set; }
        public string Code { get; set; }
        public bool Reelegible { get; set; }
        public decimal Precio { get; set; }
    }
}
