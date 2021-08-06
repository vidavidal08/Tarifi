using System.Collections.Generic;
using System.Linq;

namespace NicosApp.Core.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            IsOk = succeeded;
            Errores = errors.ToArray();
        }
        internal Result(bool succeeded, string Mensaje)
        {
            IsOk = succeeded;
            this.Mensaje = Mensaje;
        }
        public bool IsOk { get; set; }
        public string[] Errores { get; set; }
        public string Mensaje { get; set; }
        public static Result Success(string mensaje)
        {
            return new Result(true, mensaje);
        }
        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}