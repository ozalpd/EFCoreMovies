using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Models
{
    public class GenreThinDTO
    {
        [Key]
        public int Id { get; set; }

        [Required()]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
