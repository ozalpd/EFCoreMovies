using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configs
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasIndex(p => p.Title);
            builder.HasIndex(p => p.ReleaseDate);
            builder.Property(p => p.PosterURL).IsUnicode(false);
        }
    }
}
