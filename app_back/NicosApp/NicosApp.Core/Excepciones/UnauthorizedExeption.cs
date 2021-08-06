using System;
using System.Globalization;

namespace NicosApp.Core.Excepciones
{
    public class UnauthorizedExeption : Exception
    {
        public UnauthorizedExeption() : base()
        {
        }

        public UnauthorizedExeption(string message) : base(message)
        {
        }

        public UnauthorizedExeption(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}