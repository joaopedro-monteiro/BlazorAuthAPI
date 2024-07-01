namespace BlazorAuthAPI.Core.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cpf { get; set; }
        public string? Role { get; set; }
    }
}
