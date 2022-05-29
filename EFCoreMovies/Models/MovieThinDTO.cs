using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Models
{
    public class MovieThinDTO
    {

        [Key]
        public int Id { get; set; }

        [Required()]
        [MaxLength(200)]
        public string Title { get; set; }

        public bool InCinemas { get; set; }

        [MaxLength(500)]
        public string PosterURL { get; set; }

        public string ImdbURL { get; set; }

        //[Column(TypeName = "Date")]
        public DateTime? ReleaseDate { get; set; }
    }
}
