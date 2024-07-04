using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;

namespace Duett.Api.Middlewares.Error.ValueObjects;

public class ErrorResult
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };

    public ErrorResult()
    {
    }

    private ErrorResult(ValidationException validationException)
    {
        var failure = validationException.Errors.FirstOrDefault();

        StatusCode = HttpStatusCode.BadRequest;
        Message = failure?.ErrorMessage ?? validationException.Message;
        Errors = validationException.Errors?.Select(f => new Error(f)).ToList();
        Details = validationException.ToString();
    }

    private ErrorResult(UnauthorizedAccessException unauthorizedAccessException)
    {
        StatusCode = HttpStatusCode.Unauthorized;
        Message = unauthorizedAccessException.Message;
        Details = unauthorizedAccessException.ToString();
    }

    private ErrorResult(Exception exception)
    {
        StatusCode = HttpStatusCode.InternalServerError;
        Message = exception.Message;
        Details = exception.ToString();
    }

    private ErrorResult(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Message = statusCode.ToString();
    }

    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }
    public List<Error>? Errors { get; set; }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this, Options);
    }

    public static ErrorResult Build(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ErrorResult(validationException),
            UnauthorizedAccessException unauthorizedAccessException => new ErrorResult(unauthorizedAccessException),
            _ => new ErrorResult(exception)
        };
    }

    public static ErrorResult Unauthorized()
    {
        return new ErrorResult(HttpStatusCode.Unauthorized);
    }
}