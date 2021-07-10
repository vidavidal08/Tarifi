using NicosApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.Core.Entidades
{
    /// <summary>
    /// Se trata de un quinto par de dígitos adicionado a los ocho dígitos 
    /// que componen actualmente una fracción arancelaria.
    /// </summary>
    public class FraccionArancelaria : BaseEntity<Guid>
    {

   
        /// <summary>
        /// 
        /// </summary>
        public string ClaveFraccion { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; }



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
        public virtual ICollection<PermisoFraccion> PermisosFraccion { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Nico> Nicos{ get; set; }

    }
}
