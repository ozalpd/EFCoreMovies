using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class CinemaOffer
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BeginDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? EndDate { get; set; }

        [Precision(precision: 8, scale: 4)]
        public decimal DiscountPercentage { get; set; }

        //EF Core will detect that this is a foreign key to Cinemas table
        public int CinemaId { get; set; }
    }
}
