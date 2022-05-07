using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configs
{
    public class CinemaOfferConfig : IEntityTypeConfiguration<CinemaOffer>
    {
        public void Configure(EntityTypeBuilder<CinemaOffer> builder)
        {
            builder.HasIndex(p => p.CinemaId);
            builder.HasIndex(p => p.BeginDate);
            builder.Property(p => p.DiscountPercentage).HasPrecision(precision: 8, scale: 4);
        }
    }
}
