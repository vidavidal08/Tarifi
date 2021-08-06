using CsvHelper.Configuration;
using MediatR;

namespace NicosApp.Core.Feactures.Fraccion.Commands.CreateCSVFraccionPermisoAcotacion
{
    public class FraccionPermisoAcotacionCSV : INotification
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
        public string Acotacion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Perniso { get; set; }
        public class FraccionPernisoAcotacionCSVMap : ClassMap<FraccionPermisoAcotacionCSV>
        {
            public FraccionPernisoAcotacionCSVMap()
            {

                Map(m => m.ClaveFraccion).Index(0);
                Map(m => m.Descripcion).Index(1);
                Map(m => m.Acotacion).Index(2);
                Map(m => m.Perniso).Index(3);

            }
        }
    }
}
