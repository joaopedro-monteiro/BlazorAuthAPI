using BlazorAuthAPI.Core.Shared.Extensions;
using FluentValidation.Results;

namespace Duett.Api.Middlewares.Error.ValueObjects;

public class Error
{
    public Error()
    {
    }

    public Error(ValidationFailure failure)
    {
        Property = string.Join('.', failure.PropertyName.Split('.').Select(p => p.FirstLetterToLower()));
        PropertyName = failure.PropertyName;
        ErrorMessage = failure.ErrorMessage;

        var values = failure.FormattedMessagePlaceholderValues;

        if (values != null && values.TryGetValue("PropertyName", out var value))
            PropertyName = value.ToString() ?? PropertyName;
    }

    public string? Property { get; set; }
    public string? PropertyName { get; set; }
    public string? ErrorMessage { get; set; }
}