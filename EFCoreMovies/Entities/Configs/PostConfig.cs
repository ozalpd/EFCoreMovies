using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasIndex(p => p.ParentPostId);
            builder.HasIndex(p => p.SenderId);
            builder.HasIndex(p => p.Subject);

            builder.Property<DateTime>("CreateDate")
                   .HasDefaultValueSql("GetDate()")
                   .HasColumnType("datetime2");
        }
    }
}
