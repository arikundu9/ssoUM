using System.Net;
using Newtonsoft.Json;
using ssoUM.Utils;

namespace ssoUM.Middlewares;
public class GlobalExceptionMiddleware
{

    private readonly RequestDelegate _next;

    private readonly ILogger<AuthTokenMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<AuthTokenMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new RestResponse<bool>().ErrMsg($"SystemException :: {((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}");

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
