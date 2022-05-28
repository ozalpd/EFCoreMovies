using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    //[Table(name: "Genres", Schema = "mov")]
    public class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required()]
        [MaxLength(100)]
        //[Column(name: "GenreName")]
        public string Name { get; set; }

        //EF Core will detect that this is a many-to-many relationship to Movies table
        public ICollection<Movie> Movies { get; set; }
    }
}
