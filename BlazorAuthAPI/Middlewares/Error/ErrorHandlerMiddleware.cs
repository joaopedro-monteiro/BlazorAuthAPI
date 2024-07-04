using Duett.Api.Middlewares.Error.ValueObjects;

namespace Duett.Api.Middlewares.Error;

public class ErrorHandlerMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception exception)
        {
            await WriteError(httpContext, exception);
        }
    }

    private static async Task WriteError(HttpContext httpContext, Exception error)
    {
        var errorResult = ErrorResult.Build(error);
        var json = errorResult.ToJson();
        var response = httpContext.Response;

        response.StatusCode = (int)errorResult.StatusCode;
        response.ContentType = "application/json";

        await response.WriteAsync(json);
    }
}