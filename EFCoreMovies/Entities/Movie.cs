using EFCoreMovies.Models;

namespace EFCoreMovies.Entities
{
    public class Movie : MovieThinDTO
    {
        public Movie()
        {
            CinemaHalls = new HashSet<CinemaHall>();
            Genres = new HashSet<Genre>();
            MoviesActors = new HashSet<MovieActor>();
        }

        //EF Core will detect that this is a many-to-many relationship to CinemaHalls table
        public ICollection<CinemaHall> CinemaHalls { get; set; }

        //EF Core will detect that this is a many-to-many relationship to Genres table
        public ICollection<Genre> Genres { get; set; }

        public ICollection<MovieActor> MoviesActors { get; set; }
    }
}