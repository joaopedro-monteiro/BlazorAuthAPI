using BlazorAuthAPI.Core.Shared.Helpers;
using BlazorAuthAPI.Core.Shared.Jwt;

namespace BlazorAuthAPI.Core.Results
{
    public class LoginResult
    {
        public LoginResult(User.Entities.User user)
        {
            var userInfo = new Dictionary<string, string>
            {
                { "userId", user.Id.ToString() },
                { "accessLevel", user.Role.ToString() }
            };

            if (!string.IsNullOrEmpty(user.Name))
                userInfo.Add("name", user.Name);

            if (!string.IsNullOrEmpty(user.Email))
                userInfo.Add("email", user.Email);

            if (!string.IsNullOrEmpty(user.Cpf))
                userInfo.Add("cpf", user.Cpf);

            Token = JwtService.GenerateToken(userInfo);
            UserId = user.Id;
        }

        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}
