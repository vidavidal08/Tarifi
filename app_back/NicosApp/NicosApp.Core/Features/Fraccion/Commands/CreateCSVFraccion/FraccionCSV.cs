using CsvHelper.Configuration;
using MediatR;

namespace NicosApp.Core.Features.Fraccion.Commands.CreateCSVFraccion
{
    public class FraccionCSV : INotification
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
    }
    public class FraccionCSVMap : ClassMap<FraccionCSV>
    {
        public FraccionCSVMap()
        {

            Map(m => m.ClaveFraccion).Index(0);
            Map(m => m.Descripcion).Index(1);
            Map(m => m.UnidadMedida).Index(2);
            Map(m => m.IGI).Index(3);
            Map(m => m.IGE).Index(4);
        }
    }
}

