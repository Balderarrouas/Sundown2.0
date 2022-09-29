using System;
using System.Globalization;

namespace Sundown2._0.ExceptionHandling.Exceptions
{
    public class CustomApplicationException : Exception
    {
        public CustomApplicationException() : base()
        {

        }
        public CustomApplicationException(string message) : base(message)
        {

        }

        public CustomApplicationException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
