using BlazorAuthAPI.Core.User.Enum;

namespace BlazorAuthAPI.Core.User.Commands
{
    public class AddNewUserCommand
    {
        private string? _email;
        private string? _name;

        public string? Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        public string? Email
        {
            get => _email;
            set => _email = value?.Trim().ToLower();
        }

        public string? Password { get; set; }
        public string? Cpf { get; set; }
        public AccessLevel Role { get; set; }
    }
}
