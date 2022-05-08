using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Configs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreMovies
{
    public class AppDbContext : DbContext
    {
        private const string mov = "mov";

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //We use SQL's DateTime rarely, so I set default column type as date
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Brings and applies all entity configuration classes when model builder generates a migration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //This a is better way to set a schema here than using data annotations.
            //Because all tables without a default schema (or without a default name) can be seen in one place.
            //So below lines deliberately kept here instead of moving into IEntityTypeConfiguration classes.
            modelBuilder.Entity<Actor>().ToTable(name: "Actors", schema: mov);
            modelBuilder.Entity<Cinema>().ToTable(name: "Cinemas", schema: mov);
            modelBuilder.Entity<CinemaHall>().ToTable(name: "CinemaHalls", schema: mov);
            modelBuilder.Entity<CinemaOffer>().ToTable(name: "CinemaOffers", schema: mov);
            modelBuilder.Entity<Genre>().ToTable(name: "Genres", schema: mov);
            modelBuilder.Entity<MovieActor>().ToTable(name: "MoviesActors", schema: mov);
            modelBuilder.Entity<Movie>().ToTable(name: "Movies", schema: mov);

            //It's better way to use data annotations to set required fields or set a max lenght.
            //Because annotations can be used in data validations and front end
            //modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired();


            SeedSampleData.Seed(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
