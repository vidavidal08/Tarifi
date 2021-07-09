using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Autor: ISC. Magdiel Efrain Palacios Rivera
/// Fecha: 20-02-2021
/// </summary>
namespace NicosApp.Core.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
