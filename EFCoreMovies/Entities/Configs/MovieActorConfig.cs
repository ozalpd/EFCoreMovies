using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configs
{
    public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(p => new { p.ActorId, p.MovieId });
            builder.HasIndex(p => p.CharacterName);
            builder.HasIndex(p => p.DisplayOrder);
            builder.Property(p => p.DisplayOrder).HasDefaultValue(10000);
        }
    }
}
