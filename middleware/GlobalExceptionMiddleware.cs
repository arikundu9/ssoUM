using System.Net;
using Newtonsoft.Json;
using ssoUM.Utils;

namespace ssoUM.Middlewares;
public class GlobalExceptionMiddleware
{
    public async Task InvokeAsync(HttpContext context, Func<Task> next)
    {
        try
        {
            await next();
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
