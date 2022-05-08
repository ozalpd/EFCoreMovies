using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Entities.Configs
{
    public static class SeedSampleData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var action = new Genre { Id = 1, Name = "Action" };
            var animation = new Genre { Id = 2, Name = "Animation" };
            var comedy = new Genre { Id = 3, Name = "Comedy" };
            var sciFi = new Genre { Id = 4, Name = "Science Fiction" };
            var drama = new Genre { Id = 5, Name = "Drama" };
            var romance = new Genre { Id = 6, Name = "Romance" };


            modelBuilder.Entity<Genre>().HasData(action, animation, comedy, sciFi, drama, romance);

            var tomHolland = new Actor() { Id = 1, Name = "Tom Holland", DateOfBirth = new DateTime(1996, 6, 1), Biography = "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theatre in 2008, playing a supporting part" };
            var samuelJackson = new Actor() { Id = 2, Name = "Samuel L. Jackson", DateOfBirth = new DateTime(1948, 12, 21), Biography = "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles)." };
            var robertDowney = new Actor() { Id = 3, Name = "Robert Downey Jr.", DateOfBirth = new DateTime(1965, 4, 4), Biography = "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career." };
            var chrisEvans = new Actor() { Id = 4, Name = "Chris Evans", DateOfBirth = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Name = "Dwayne Johnson", DateOfBirth = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Name = "Auli'i Cravalho", DateOfBirth = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Name = "Scarlett Johansson", DateOfBirth = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Name = "Keanu Reeves", DateOfBirth = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);

            var avengers = new Movie()
            {
                Id = 1,
                Title = "Avengers",
                InCinemas = false,
                ReleaseDate = new DateTime(2012, 4, 11),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var moviesId = "MoviesId";

            var entityGenreMovie = "GenreMovie";
            var genresId = "GenresId";

            modelBuilder.Entity(entityGenreMovie).HasData(
                new Dictionary<string, object>
                {
                    [genresId] = action.Id,
                    [moviesId] = avengers.Id
                },
                 new Dictionary<string, object>
                 {
                     [genresId] = sciFi.Id,
                     [moviesId] = avengers.Id
                 }
                );

            var coco = new Movie()
            {
                Id = 2,
                Title = "Coco",
                InCinemas = false,
                ReleaseDate = new DateTime(2017, 11, 22),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(entityGenreMovie).HasData(
               new Dictionary<string, object> { [genresId] = animation.Id, [moviesId] = coco.Id }
           );

            var noWayHome = new Movie()
            {
                Id = 3,
                Title = "Spider-Man: No way home",
                InCinemas = false,
                ReleaseDate = new DateTime(2022, 12, 17),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entityGenreMovie).HasData(
               new Dictionary<string, object> { [genresId] = sciFi.Id, [moviesId] = noWayHome.Id },
               new Dictionary<string, object> { [genresId] = action.Id, [moviesId] = noWayHome.Id },
               new Dictionary<string, object> { [genresId] = comedy.Id, [moviesId] = noWayHome.Id }
           );

            var farFromHome = new Movie()
            {
                Id = 4,
                Title = "Spider-Man: Far From Home",
                InCinemas = false,
                ReleaseDate = new DateTime(2019, 7, 2),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entityGenreMovie).HasData(
               new Dictionary<string, object> { [genresId] = sciFi.Id, [moviesId] = farFromHome.Id },
               new Dictionary<string, object> { [genresId] = action.Id, [moviesId] = farFromHome.Id },
               new Dictionary<string, object> { [genresId] = comedy.Id, [moviesId] = farFromHome.Id }
           );

            var theMatrixResurrections = new Movie()
            {
                Id = 5,
                Title = "The Matrix Resurrections",
                InCinemas = true,
                ReleaseDate = new DateTime(2023, 1, 1),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(entityGenreMovie).HasData(
              new Dictionary<string, object> { [genresId] = sciFi.Id, [moviesId] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [genresId] = action.Id, [moviesId] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [genresId] = drama.Id, [moviesId] = theMatrixResurrections.Id }
          );

            var keanuReevesMatrix = new MovieActor
            {
                ActorId = keanuReeves.Id,
                MovieId = theMatrixResurrections.Id,
                DisplayOrder = 1,
                CharacterName = "Neo"
            };

            var avengersChrisEvans = new MovieActor
            {
                ActorId = chrisEvans.Id,
                MovieId = avengers.Id,
                DisplayOrder = 1,
                CharacterName = "Capitán América"
            };

            var avengersRobertDowney = new MovieActor
            {
                ActorId = robertDowney.Id,
                MovieId = avengers.Id,
                DisplayOrder = 2,
                CharacterName = "Iron Man"
            };

            var avengersScarlettJohansson = new MovieActor
            {
                ActorId = scarlettJohansson.Id,
                MovieId = avengers.Id,
                DisplayOrder = 3,
                CharacterName = "Black Widow"
            };

            var tomHollandFFH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = farFromHome.Id,
                DisplayOrder = 1,
                CharacterName = "Peter Parker"
            };

            var tomHollandNWH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = noWayHome.Id,
                DisplayOrder = 1,
                CharacterName = "Peter Parker"
            };

            var samuelJacksonFFH = new MovieActor
            {
                ActorId = samuelJackson.Id,
                MovieId = farFromHome.Id,
                DisplayOrder = 2,
                CharacterName = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Movie>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);

            modelBuilder.Entity<MovieActor>().HasData(samuelJacksonFFH, tomHollandFFH,
                tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);



            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cinema()
            {
                Id = 1,
                Name = "Agora Mall",
                Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233))
            };
            var sambil = new Cinema()
            {
                Id = 2,
                Name = "Sambil",
                Location = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455))
            };
            var megacentro = new Cinema()
            {
                Id = 3,
                Name = "Megacentro",
                Location = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662))
            };
            var acropolis = new Cinema()
            {
                Id = 4,
                Name = "Acropolis",
                Location = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649))
            };

            modelBuilder.Entity<Cinema>().HasData(agora, sambil, megacentro, acropolis);
        }
    }
}
