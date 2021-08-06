using NicosApp.Core.Dtos;
using NicosApp.Core.Features.Fraccion.Queries.GetFraccionArancelariaList;
using System;
using System.Collections.Generic;

namespace NicosApp.Core.Features.Fraccion.Querys.GetNicoList
{
    public class FraccionArancelariaDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid  Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClaveFraccion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string UnidadMedida { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IGI { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IGE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<PermisoFraccionDto> Permisos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<NicoDto> Nicos { get; set; }
    }
}
