using Microsoft.AspNetCore.Http;
using Sundown2._0.ExceptionHandling.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sundown2._0.ExceptionHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = ApiResponse<string>.Fail(error.Message);
                switch (error)
                {
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;

                    case CustomNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case CustomApplicationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case CustomFetchFromApiException e:
                        response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                        break;

                    case CustomValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);


            }


        }

    }
}
