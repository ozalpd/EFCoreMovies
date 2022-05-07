using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Point Location { get; set; }


        [Precision(precision: 8, scale: 4)]
        public decimal TicketPrice { get; set; }

    }
}
