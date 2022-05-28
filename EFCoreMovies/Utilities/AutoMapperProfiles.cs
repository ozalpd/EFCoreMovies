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
            CreateMap<Genre, GenreThinDTO>();
            CreateMap<GenreThinDTO, Genre>();

            CreateMap<Movie, MovieThinDTO>();
            CreateMap<Movie, MovieListDTO>()
                .ForMember(dto => dto.Actors, ent => ent.MapFrom(m => m.MoviesActors.Select(ma => ma.Actor)))
                .ForMember(dto => dto.Genres, ent => ent.MapFrom(m => m.Genres));
            CreateMap<Movie, MovieFullDTO>()
                .ForMember(dto => dto.Actors, ent => ent.MapFrom(m => m.MoviesActors.Select(ma => ma.Actor)))
                .ForMember(dto => dto.Cinemas, ent => ent.MapFrom(m => m.CinemaHalls.Select(ch => ch.Cinema)))
                .ForMember(dto => dto.Genres, ent => ent.MapFrom(m => m.Genres));
        }
    }
}
