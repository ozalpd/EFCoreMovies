namespace EFCoreMovies.Models
{
    public class GenreDTO : GenreThinDTO
    {
        public GenreDTO()
        {
            Movies = new HashSet<MovieThinDTO>();
        }

        public ICollection<MovieThinDTO> Movies { get; set; }
    }
}
