using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace Api.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingForUpdate, Booking>();
            CreateMap<Booking, BookingForUpdate>();
        }
    }
}
