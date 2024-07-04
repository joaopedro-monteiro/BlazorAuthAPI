using System.Text.Json.Serialization;
using BlazorAuthAPI.Core.Shared.Helpers;
using BlazorAuthAPI.Core.User.Enum;

namespace BlazorAuthAPI.Core.User.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        [JsonIgnore] 
        public string? PasswordHashed { get; set; }
        public string? Cpf { get; set; }
        public AccessLevel Role { get; set; }
    }
}
