using AutoMapper;
using GigFeed.Dtos;

namespace GigFeed.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Notification, NotificationDto>();
            CreateMap<Gig, GigDto>();
        }
    }
}