using System.Security.Claims;

namespace BlazorAuthAPI.Extensions;

public static class ClaimExtensions
{
    public static Guid FirstClaimValueAsGuidOrDefault(this IEnumerable<Claim> claims, string type)
    {
        var value = claims.FirstClaimValueOrDefault(type);

        if (string.IsNullOrEmpty(value))
            return Guid.Empty;

        return Guid.TryParse(value, out var guidValue) ? guidValue : Guid.Empty;
    }

    public static TEnum FirstClaimValueAsEnumOrDefault<TEnum>(this IEnumerable<Claim> claims, string type)
        where TEnum : struct
    {
        var value = claims.FirstClaimValueOrDefault(type);

        if (string.IsNullOrEmpty(value))
            return default;

        return Enum.TryParse<TEnum>(value, out var enumValue) ? enumValue : default;
    }

    public static string? FirstClaimValueOrDefault(this IEnumerable<Claim> claims, string type)
    {
        var claim = claims.FirstClaimOrDefault(type);

        return claim?.Value;
    }

    private static Claim? FirstClaimOrDefault(this IEnumerable<Claim> claims, string type)
    {
        return claims.FirstOrDefault(c => c.Type == type);
    }
}

