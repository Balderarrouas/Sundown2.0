using System;
using System.Globalization;

namespace Sundown2._0.ExceptionHandling.Exceptions
{
    public class CustomNotFoundException : Exception
    {
        public CustomNotFoundException() : base()
        {

        }
        public CustomNotFoundException(string message) : base(message)
        {

        }

        public CustomNotFoundException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }

    }
}
