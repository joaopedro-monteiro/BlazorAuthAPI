namespace BlazorAuthAPI.Core.User.Commands
{
    public class LoginCommand
    {
        private string? _email;

        public string? Email
        {
            get => _email;
            set => _email = value?.Trim().ToLower();
        }

        public string? Password { get; set; }
    }
}
