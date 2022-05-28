using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Models
{
    public class CinemaDTO : CinemaThinDTO
    {
        public int? Distance { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
