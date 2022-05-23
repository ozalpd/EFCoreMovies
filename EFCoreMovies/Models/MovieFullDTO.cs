namespace EFCoreMovies.Models
{
    public class MovieFullDTO : MovieListDTO
    {
        public MovieFullDTO()
        {
            Cinemas = new HashSet<CinemaDTO>();
        }

        public ICollection<CinemaDTO> Cinemas { get; set; }
    }
}
