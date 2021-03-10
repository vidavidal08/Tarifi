using NicosApp.Core.Feactures.Fraccion.Queries.GetFraccionArancelariaList;
using System;
using System.Collections.Generic;

namespace NicosApp.Core.Feactures.Fraccion.Querys.GetNicoList
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
        public virtual ICollection<NicoDto> Nicos { get; set; }



    }
}
