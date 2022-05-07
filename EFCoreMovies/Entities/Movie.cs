using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required()]
        [MaxLength(200)]
        public string Title { get; set; }

        public bool InCinemas { get; set; }

        [MaxLength(500)]
        public string PosterURL { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ReleaseDate { get; set; }
    }
}