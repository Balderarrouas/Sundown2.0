using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.ExceptionHandling.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException() : base()
        {

        }
        public CustomValidationException(string message) : base(message)
        {

        }

        public CustomValidationException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
