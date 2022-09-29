namespace Sundown2._0.ExceptionHandling
{
    public class ApiResponse<T>
    {
        
        public string Message { get; set; }

        public static ApiResponse<T> Fail(string ErrorMessage)
        {
            return new ApiResponse<T> {Message = ErrorMessage };
        }

       
    }
}
