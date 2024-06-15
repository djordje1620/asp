using AutoMapper;
using FluentValidation;
using Rentaly.Application.Exceptions;
using Rentaly.Application.Logging;

namespace Rentaly.API.Core
{
    public class GlobalExceptionHandler(RequestDelegate next, IExceptionLogger logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly IExceptionLogger _logger = logger;

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);

                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                
                if (ex is UnauthorizedAccessException unauthEx)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new { message = unauthEx.Message };
                }

                if (ex is ValidationException e)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = e.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                }

                if (ex is EntityNotFoundException notFoundEx)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    response = new { message = notFoundEx.Message };
                }

                if (ex is ForbiddenAccessException exMsg)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                    response = new { message = exMsg.Message };
                }

                if (ex is ForbiddenUseCaseExecutionException msg)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                    response = new { message = msg.Message };
                }

                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
