using System;
using System.Net;

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
