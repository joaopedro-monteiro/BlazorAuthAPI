using BlazorAuthAPI.Core.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.Repository.User
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public Models.User Create(Models.User model)
        {
            context.Users.Add(model);
            context.SaveChanges();

            return model;
        }

        public void DeleteById(Guid id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                return;

            context.Users.Remove(user);
            context.SaveChanges();
        }

        public ICollection<Models.User> FindAll()
        {
            var users = context.Users.AsNoTracking().ToList();
            
            return users;
        }
    }
}
