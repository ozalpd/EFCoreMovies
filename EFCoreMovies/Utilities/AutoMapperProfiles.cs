using AutoMapper;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.DTOs;

namespace EFCoreMovies.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDTO>();
        }
    }
}
