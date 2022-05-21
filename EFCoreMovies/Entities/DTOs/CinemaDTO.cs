using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities.DTOs
{
    public class CinemaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public decimal TicketPrice { get; set; }
    }
}
