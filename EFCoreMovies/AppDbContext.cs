using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies
{
    public class AppDbContext : DbContext
    {
        private const string mov = "mov";

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //This a is better way to set a schema than using data annotations.
            //Because all tables without a default schema (or without a default name) can be seen in one place.
            modelBuilder.Entity<Actor>().ToTable(name: "Actors", schema: mov)
                                        .HasIndex(p => p.Name);

            modelBuilder.Entity<Cinema>().ToTable(name: "Cinemas", schema: mov)
                                         .HasIndex(p => p.Name);
            
            modelBuilder.Entity<CinemaOffer>().ToTable(name: "CinemaOffers", schema: mov)
                                              .HasIndex(p => p.CinemaId);
            modelBuilder.Entity<CinemaOffer>().HasIndex(p => p.BeginDate);

            modelBuilder.Entity<Genre>().ToTable(name: "Genres", schema: mov)
                                        .HasIndex(p => p.Name);

            modelBuilder.Entity<Movie>().ToTable(name: "Movies", schema: mov)
                                        .HasIndex(p => p.Title);
            modelBuilder.Entity<Movie>().HasIndex(p => p.ReleaseDate);


            modelBuilder.Entity<Movie>().Property(p => p.PosterURL).IsUnicode(false);

            //It's better way to use data annotations to set required fields or set a max lenght.
            //Because annotations can be used in data validations and front end
            //modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired();
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
