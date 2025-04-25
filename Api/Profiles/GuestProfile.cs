using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace Api.Profiles
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<GuestForUpdate, Guest>();
            CreateMap<Guest, GuestForUpdate>();
        }
    }
}
