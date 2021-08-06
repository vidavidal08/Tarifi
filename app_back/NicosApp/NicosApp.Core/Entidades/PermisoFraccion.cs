using NicosApp.Core.Common;
using System;

namespace NicosApp.Core.Entidades
{
    public class PermisoFraccion : BaseEntity<Guid>
    {
        public string Permiso { get; set; }
        public string Acotacion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid IdFraccionArancelaria { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual FraccionArancelaria FraccionArancelaria { get; set; }
    }
}
