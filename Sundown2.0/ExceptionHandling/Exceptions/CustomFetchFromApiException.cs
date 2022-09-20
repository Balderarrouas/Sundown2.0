using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.ExceptionHandling.Exceptions
{
    public class CustomFetchFromApiException : Exception
    {
        public CustomFetchFromApiException() : base()
        {

        }
        public CustomFetchFromApiException(string message) : base(message)
        {

        }

        public CustomFetchFromApiException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
