using BlazorAuthAPI.Core.User.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.User
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        Guid UserId { get; }
        string? Name { get; }
        string? Email { get; }
        string? Cpf { get; }
        AccessLevel Role { get; }
        bool IsAdmin { get; }
        List<Claim> Claims { get; }
    }
}
