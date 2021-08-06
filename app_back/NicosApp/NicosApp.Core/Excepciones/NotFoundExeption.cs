using System;
using System.Globalization;

namespace NicosApp.Core.Excepciones
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption() : base()
        {
        }
        public NotFoundExeption(string message) : base(message)
        {
        }
        public NotFoundExeption(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}