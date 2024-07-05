using BlazorAuth.Enum;

namespace BlazorAuth.Commands;

public class UserCommand
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PasswordHashed { get; set; }
    public string? Cpf { get; set; }
    public AccessLevel? Role { get; set; }
}

