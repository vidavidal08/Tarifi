using CsvHelper.Configuration;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 22-02-2021
/// </summary>
namespace NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos
{
    public class NicoCSV
    {
        /// <summary>
        /// 
        /// </summary>
        public string FraccionArancelaTIGIE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NICO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; }
    }
    public class NicoCSVMap : ClassMap<NicoCSV>
    {
        public NicoCSVMap()
        {
            Map(m => m.FraccionArancelaTIGIE).Index(0);
            Map(m => m.NICO).Index(1);
            Map(m => m.Descripcion).Index(2);
        }
    }
}
