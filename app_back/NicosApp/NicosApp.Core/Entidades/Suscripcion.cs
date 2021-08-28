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
        public int TipoSuscripcionId { get; set; }
        public TipoSuscripcion TipoSuscripcion { get; set; }

        /// <summary>
        /// FK
        /// </summary>
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        /// <summary>
        /// FK
        /// </summary>
        public Guid PaqueteID { get; set; }
        public Paquete Paquete { get; set; }
    }
}
