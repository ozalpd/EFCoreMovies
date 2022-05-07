using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Actor
    {
        public Actor()
        {
            MoviesActors = new HashSet<MovieActor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Biography { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<MovieActor> MoviesActors { get; set; }
    }
}
