using Newtonsoft.Json;
using System.Net;
using WebApi.Users.Middleware.Exceptions;

namespace WebApi.Users.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate _next, ILogger<ExceptionMiddleware> logger)
        {
            this._next = _next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong while processing the path {context.Request.Method}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private  Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errors = new ErrorDetails
            {
                ErrorStatus = statusCode.ToString(),
                ErrorDescription = ex.Message
            };

            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errors.ErrorStatus = HttpStatusCode.NotFound.ToString();
                    errors.ErrorDescription = ex.Message;
                    break;
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    errors.ErrorStatus = HttpStatusCode.BadRequest.ToString();
                    errors.ErrorDescription=ex.Message;
                    break ;
                default:
                    break;
            }
            
            string _response = JsonConvert.SerializeObject(errors);
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(_response);

        }
    }
}
