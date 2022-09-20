using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.ExceptionHandling
{
    public class ApiResponse<T>
    {
        // public T Data { get; set; }
        // public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static ApiResponse<T> Fail(string ErrorMessage)
        {
            return new ApiResponse<T> {Message = ErrorMessage };
        }

        //public static ApiResponse<T> Success(T Data)
        //{
        //    return new ApiResponse<T> { Succeeded = true, Data = Data };
        //}
    }
}
