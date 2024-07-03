using BlazorAuth.Models;

namespace BlazorAuth.Services
{
    public class UserService(HttpClient httpClient) : IUserService
    {
        public async Task<User> Create(User model)
        {
            //var cliente = await httpClient.PostAsJsonAsync("/api/", model)
            throw new NotImplementedException();
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
