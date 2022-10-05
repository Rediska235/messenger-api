using AutoMapper;
using Messenger.Dtos;
using Messenger.Models;

namespace Messenger.Profiles;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, MessageReadDto>()
            .ForMember(dest => dest.Author, 
                opt => opt.MapFrom(m => m.Author.Username));
    }
}