using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities
{
    public class CinemaHall
    {
        public CinemaHall()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public CinemaHallType CinemaHallType { get; set; }
        public Currency Currency { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [Precision(precision: 8, scale: 4)]
        public decimal TicketPrice { get; set; }

        //EF Core will detect that this is a many-to-many relationship to Movies table
        public ICollection<Movie> Movies { get; set; }
    }
}
