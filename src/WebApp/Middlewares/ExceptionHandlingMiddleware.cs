using System.Net;
using System.Text.Json;
using Serilog;

namespace WebApp.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private static IDictionary<Type, HttpStatusCode> Mappings => new Dictionary<Type, HttpStatusCode>
    {
        {typeof (ArgumentNullException), HttpStatusCode.BadRequest},
        {typeof (ArgumentException), HttpStatusCode.BadRequest},
        {typeof (ArgumentOutOfRangeException), HttpStatusCode.BadRequest},
        {typeof (InvalidOperationException), HttpStatusCode.BadRequest},
        {typeof (KeyNotFoundException), HttpStatusCode.BadRequest },
        {typeof (WebException), HttpStatusCode.BadRequest }
    };

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = Mappings.ContainsKey(exception.GetType()) ? Mappings[exception.GetType()] : HttpStatusCode.InternalServerError;
        await WriteExceptionAsync(context, exception, code);
    }

    private static async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
    {
        var response = context.Response;
        response.StatusCode = (int)code;
        response.ContentType = "application/json";
        await response.WriteAsync(JsonSerializer.Serialize(new
        {
            error = new
            {
                message = exception.Message,
                exception = exception.GetType().Name
            }
        }));
    }
}
