using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities
{
    public class Cinema
    {
        public Cinema()
        {
            CinemaHalls = new HashSet<CinemaHall>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Point Location { get; set; }


        [Precision(precision: 8, scale: 4)]
        public decimal TicketPrice { get; set; }


        public ICollection<CinemaHall> CinemaHalls { get; set; }

        //EF Core will detect that this is a one-to-one relationship to CinemaOffers table
        public CinemaOffer CinemaOffer { get; set; }
    }
}
