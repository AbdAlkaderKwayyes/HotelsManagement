using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace Api.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomForUpdate, Room>();
            CreateMap<Room, RoomForUpdate>();
        }
    }
}
