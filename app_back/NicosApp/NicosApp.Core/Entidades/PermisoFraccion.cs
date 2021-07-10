using NicosApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
