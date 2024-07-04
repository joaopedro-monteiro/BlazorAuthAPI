using AutoMapper;
using BlazorAuthAPI.Core.User.Commands;

namespace BlazorAuthAPI.Core.User.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddNewUserCommand, Entities.User>();
        }
    }
}
