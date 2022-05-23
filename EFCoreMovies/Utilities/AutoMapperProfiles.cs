using AutoMapper;
using EFCoreMovies.Entities;
using EFCoreMovies.Models;

namespace EFCoreMovies.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDTO>();
            CreateMap<Cinema, CinemaDTO>()
                .ForMember(dto => dto.Latitude, ent => ent.MapFrom(p => p.Location.Y))
                .ForMember(dto => dto.Longitude, ent => ent.MapFrom(p => p.Location.X));
            
            CreateMap<Genre, GenreDTO>();
            CreateMap<Movie, MovieThinDTO>();
        }
    }
}
