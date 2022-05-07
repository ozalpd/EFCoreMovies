using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Movie
    {
        public Movie()
        {
            CinemaHalls = new HashSet<CinemaHall>();
            Genres = new HashSet<Genre>();
            MoviesActors = new HashSet<MovieActor>();
        }

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

        //EF Core will detect that this is a many-to-many relationship to CinemaHalls table
        public ICollection<CinemaHall> CinemaHalls { get; set; }

        //EF Core will detect that this is a many-to-many relationship to Genres table
        public ICollection<Genre> Genres { get; set; }

        public ICollection<MovieActor> MoviesActors { get; set; }
    }
}