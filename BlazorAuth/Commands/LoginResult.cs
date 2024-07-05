namespace BlazorAuth.Commands
{
    public class LoginResult
    {
        public string? Token { get; set; }
        public Guid UserId { get; set; }
    }
}