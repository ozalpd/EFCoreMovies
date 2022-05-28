using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Models
{
    public class CinemaThinDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
