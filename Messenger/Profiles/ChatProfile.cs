using AutoMapper;
using Messenger.Dtos;
using Messenger.Models;

namespace Messenger.Profiles;

public class ChatProfile : Profile
{
    public ChatProfile()
    {
        CreateMap<Chat, ChatReadDto>();
    }    
}