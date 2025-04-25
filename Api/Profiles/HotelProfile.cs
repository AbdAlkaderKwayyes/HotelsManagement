using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace Api.Profiles
{
    public class HotelProfile:Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelForUpdate, Hotel>();
            CreateMap<Hotel, HotelForUpdate>();
        }
    }
}
