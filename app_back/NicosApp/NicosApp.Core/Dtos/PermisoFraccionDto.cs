using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Dtos
{
   public class PermisoFraccionDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        public string Permiso { get; set; }

        public string Acotacion { get; set; }
    }
}
