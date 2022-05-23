using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Models
{
    public class ActorDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
