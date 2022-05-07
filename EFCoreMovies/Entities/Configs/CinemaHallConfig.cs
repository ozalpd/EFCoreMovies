using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configs
{
    public class CinemaHallConfig : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.HasIndex(p => p.CinemaId);
            builder.Property(p => p.TicketPrice)
                   .HasPrecision(precision: 8, scale: 4);
            builder.Property(p => p.CinemaHallType)
                   .HasDefaultValue(CinemaHallType.TwoDimensions);
        }
    }
}
