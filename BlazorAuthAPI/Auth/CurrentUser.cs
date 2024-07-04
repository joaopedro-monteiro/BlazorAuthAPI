using BlazorAuthAPI.Core.User;
using BlazorAuthAPI.Core.User.Enum;
using System.Security.Claims;
using BlazorAuthAPI.Extensions;

namespace BlazorAuthAPI.Auth;
public class CurrentUser : ICurrentUser
{
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        var httpContext = httpContextAccessor.HttpContext;
        var user = httpContext?.User;
        var claims = user?.Claims.ToList() ?? [];

        IsAuthenticated = user?.Identity?.IsAuthenticated ?? false;
        UserId = claims.FirstClaimValueAsGuidOrDefault("userId");
        Name = claims.FirstClaimValueOrDefault("name");
        Email = claims.FirstClaimValueOrDefault("email");
        Cpf = claims.FirstClaimValueOrDefault("cpf");
        Role = claims.FirstClaimValueAsEnumOrDefault<AccessLevel>("accessLevel");
        Claims = claims;
    }

    public bool IsAuthenticated { get; }
    public Guid UserId { get; }
    public string? Name { get; }
    public string? Email { get; }
    public string? Cpf { get; }
    public AccessLevel Role { get; }
    public bool IsAdmin => Role == AccessLevel.Admin;
    public List<Claim> Claims { get; }
    
}