using Application.Rides.DTOs;
using AutoMapper;
using Core.Domain.Rides;

namespace Application.Rides.Mapping
{
    public class RidesProfile : Profile
    {
        public RidesProfile()
        {
            CreateMap<Ride, AvailableRideDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Origin.Address))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Origin.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Origin.Longitude));
        }
    }
}