using AutoMapper;
using Messenger.Dtos;
using Messenger.Models;

namespace Messenger.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReadDto>();
        CreateMap<UserCreateDto, User>();
    }    
}