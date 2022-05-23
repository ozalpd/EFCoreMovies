namespace EFCoreMovies.Models
{
    public class MovieListDTO : MovieThinDTO
    {
        public MovieListDTO()
        {
            Actors = new HashSet<ActorDTO>();
            Genres = new HashSet<GenreThinDTO>();
        }

        public ICollection<ActorDTO> Actors { get; set; }
        public ICollection<GenreThinDTO> Genres { get; set; }
    }
}
