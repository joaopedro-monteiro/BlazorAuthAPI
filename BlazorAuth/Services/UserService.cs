using BlazorAuth.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorAuth.Services
{
    public class UserService(HttpClient httpClient) : IUserService
    {
        public async Task<User> Create(User model)
        {
            try
            {
                var cliente = await httpClient.PostAsJsonAsync("https://localhost:7025/api/users", model);
                var response = await cliente.Content.ReadFromJsonAsync<User>();
                return response!;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return model;
        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
