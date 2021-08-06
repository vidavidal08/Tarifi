using NicosApp.Core.Common;
using System;

namespace NicosApp.Core.Entidades
{
    public class Nico : BaseEntity<Guid>
    {
        /// <summary>
        /// PK
        /// </summary>
        public string ClaveNICO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; }
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
