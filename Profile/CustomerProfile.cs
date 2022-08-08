using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}