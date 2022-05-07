namespace EFCoreMovies.Entities
{
    public class CinemaOffer
    {
        public int Id { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal DiscountPercentage { get; set; }

        //EF Core will detect that this is a foreign key to Cinemas table
        public int CinemaId { get; set; }
    }
}
