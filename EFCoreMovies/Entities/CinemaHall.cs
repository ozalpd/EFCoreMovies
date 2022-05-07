using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [Precision(precision: 8, scale: 4)]
        public decimal TicketPrice { get; set; }

    }
}
