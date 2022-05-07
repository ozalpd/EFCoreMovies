using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
