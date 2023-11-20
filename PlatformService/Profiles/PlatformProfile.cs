using AutoMapper;
using PlatformService.Core.Models;
using PlatformService.Dtos;

namespace PlatformService.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            // source -> target

            CreateMap<Platform, PlatformReadDto>();
          
            CreateMap<PlatformCreateDto, Platform>();

            CreateMap<PlatformReadDto, PlatformPublishedDto>();



        }
    }
}
