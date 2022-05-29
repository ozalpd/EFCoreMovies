using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configs
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(p => p.Name)
                   .IsUnique().HasFilter("IsDeleted=0");
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.Property<DateTime>("CreateDate")
                   .HasDefaultValueSql("GetDate()")
                   .HasColumnType("datetime2");
        }
    }
}
