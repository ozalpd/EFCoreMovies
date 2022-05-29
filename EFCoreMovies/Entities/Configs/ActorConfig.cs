using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configs
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasIndex(p => p.Name);
            builder.Property<DateTime>("CreateDate")
                   .HasDefaultValueSql("GetDate()")
                   .HasColumnType("datetime2");
        }
    }
}
