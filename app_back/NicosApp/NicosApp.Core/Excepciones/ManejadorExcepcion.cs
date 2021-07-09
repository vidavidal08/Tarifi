using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Excepciones
{
    public class ManejadorExcepcion : Exception
    {
        public HttpStatusCode Codigo { get; }

        public object Error { get; }




        public ManejadorExcepcion(HttpStatusCode codigo, object error = null)
        {
            Codigo = codigo;
            Error = error;
        }




    }
}
