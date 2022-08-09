using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class VidlyProfile : Profile
    {
        public VidlyProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}