using NicosApp.Core.Common;
using System;

namespace NicosApp.Core.Entidades
{
    public class Suscripcion: BaseEntity<Guid>
    {
        
      
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { set; get; }
        public bool EsVigente { get; set; }


        /// <summary>
        /// FK
        /// </summary>
        public Guid IdTipoSuscripcion { get; set; }
        public virtual TipoSuscripcion TipoSuscripcion { get; set; }

        /// <summary>
        /// FK
        /// </summary>
        public string IdApplicationUser { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        /// <summary>
        /// FK
        /// </summary>
        public Guid IdPaquete { get; set; }
        public virtual Paquete Paquete { get; set; }
    }
}
