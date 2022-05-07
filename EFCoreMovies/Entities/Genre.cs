using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    //[Table(name: "Genres", Schema = "mov")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required()]
        [MaxLength(100)]
        //[Column(name: "GenreName")]
        public string Name { get; set; }
    }
}
