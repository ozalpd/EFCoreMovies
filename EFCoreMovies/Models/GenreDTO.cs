namespace EFCoreMovies.Models
{
    public class GenreDTO : GenreThinDTO
    {
        public ICollection<MovieThinDTO> Movies { get; set; }
    }
}
