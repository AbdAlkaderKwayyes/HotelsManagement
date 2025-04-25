using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace Api.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeForUpdate, Employee>();
            CreateMap<Employee, EmployeeForUpdate>();
        }
    }
}
