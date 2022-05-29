﻿// <auto-generated />
using System;
using EFCoreMovies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCoreMovies.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220529211022_createdate")]
    partial class createdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CinemaHallMovie", b =>
                {
                    b.Property<int>("CinemaHallsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CinemaHallsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CinemaHallMovie", "mov");

                    b.HasData(
                        new
                        {
                            CinemaHallsId = 3,
                            MoviesId = 5
                        },
                        new
                        {
                            CinemaHallsId = 4,
                            MoviesId = 5
                        },
                        new
                        {
                            CinemaHallsId = 1,
                            MoviesId = 5
                        },
                        new
                        {
                            CinemaHallsId = 2,
                            MoviesId = 5
                        },
                        new
                        {
                            CinemaHallsId = 5,
                            MoviesId = 5
                        },
                        new
                        {
                            CinemaHallsId = 6,
                            MoviesId = 5
                        },
                        new
                        {
                            CinemaHallsId = 7,
                            MoviesId = 5
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Actors", "mov");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theatre in 2008, playing a supporting part",
                            DateOfBirth = new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tom Holland"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles).",
                            DateOfBirth = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career.",
                            DateOfBirth = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Robert Downey Jr."
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chris Evans"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dwayne Johnson"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Auli'i Cravalho"
                        },
                        new
                        {
                            Id = 7,
                            DateOfBirth = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Scarlett Johansson"
                        },
                        new
                        {
                            Id = 8,
                            DateOfBirth = new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Keanu Reeves"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TicketPrice")
                        .HasPrecision(8, 4)
                        .HasColumnType("decimal(8,4)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Cinemas", "mov");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)"),
                            Name = "Agora Mall",
                            TicketPrice = 0m
                        },
                        new
                        {
                            Id = 2,
                            Location = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)"),
                            Name = "Sambil",
                            TicketPrice = 0m
                        },
                        new
                        {
                            Id = 3,
                            Location = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)"),
                            Name = "Megacentro",
                            TicketPrice = 0m
                        },
                        new
                        {
                            Id = 4,
                            Location = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)"),
                            Name = "Acropolis",
                            TicketPrice = 0m
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaHallType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("TicketPrice")
                        .HasPrecision(8, 4)
                        .HasColumnType("decimal(8,4)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("CinemaHalls", "mov");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            CinemaHallType = 2,
                            CinemaId = 3,
                            Currency = "",
                            TicketPrice = 250m
                        },
                        new
                        {
                            Id = 6,
                            CinemaHallType = 3,
                            CinemaId = 3,
                            Currency = "",
                            TicketPrice = 330m
                        },
                        new
                        {
                            Id = 7,
                            CinemaHallType = 4,
                            CinemaId = 3,
                            Currency = "",
                            TicketPrice = 450m
                        },
                        new
                        {
                            Id = 8,
                            CinemaHallType = 2,
                            CinemaId = 4,
                            Currency = "",
                            TicketPrice = 250m
                        },
                        new
                        {
                            Id = 1,
                            CinemaHallType = 2,
                            CinemaId = 1,
                            Currency = "",
                            TicketPrice = 220m
                        },
                        new
                        {
                            Id = 2,
                            CinemaHallType = 3,
                            CinemaId = 1,
                            Currency = "",
                            TicketPrice = 320m
                        },
                        new
                        {
                            Id = 3,
                            CinemaHallType = 2,
                            CinemaId = 2,
                            Currency = "",
                            TicketPrice = 200m
                        },
                        new
                        {
                            Id = 4,
                            CinemaHallType = 3,
                            CinemaId = 2,
                            Currency = "",
                            TicketPrice = 290m
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("Date");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPercentage")
                        .HasPrecision(8, 4)
                        .HasColumnType("decimal(8,4)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("BeginDate");

                    b.HasIndex("CinemaId")
                        .IsUnique();

                    b.ToTable("CinemaOffers", "mov");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            BeginDate = new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CinemaId = 4,
                            DiscountPercentage = 15m,
                            EndDate = new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 1,
                            BeginDate = new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CinemaId = 1,
                            DiscountPercentage = 10m,
                            EndDate = new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("IsDeleted=0");

                    b.ToTable("Genres", "mov");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Animation"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("InCinemas")
                        .HasColumnType("bit");

                    b.Property<string>("PosterURL")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ReleaseDate");

                    b.HasIndex("Title");

                    b.ToTable("Movies", "mov");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                            ReleaseDate = new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avengers"
                        },
                        new
                        {
                            Id = 2,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg",
                            ReleaseDate = new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Coco"
                        },
                        new
                        {
                            Id = 3,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            ReleaseDate = new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: No way home"
                        },
                        new
                        {
                            Id = 4,
                            InCinemas = false,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            ReleaseDate = new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: Far From Home"
                        },
                        new
                        {
                            Id = 5,
                            InCinemas = true,
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
                            ReleaseDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Matrix Resurrections"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.MovieActor", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DisplayOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10000);

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("CharacterName");

                    b.HasIndex("DisplayOrder");

                    b.HasIndex("MovieId");

                    b.ToTable("MoviesActors", "mov");

                    b.HasData(
                        new
                        {
                            ActorId = 2,
                            MovieId = 4,
                            CharacterName = "Samuel L. Jackson",
                            DisplayOrder = 2
                        },
                        new
                        {
                            ActorId = 1,
                            MovieId = 4,
                            CharacterName = "Peter Parker",
                            DisplayOrder = 1
                        },
                        new
                        {
                            ActorId = 1,
                            MovieId = 3,
                            CharacterName = "Peter Parker",
                            DisplayOrder = 1
                        },
                        new
                        {
                            ActorId = 3,
                            MovieId = 1,
                            CharacterName = "Iron Man",
                            DisplayOrder = 2
                        },
                        new
                        {
                            ActorId = 7,
                            MovieId = 1,
                            CharacterName = "Black Widow",
                            DisplayOrder = 3
                        },
                        new
                        {
                            ActorId = 4,
                            MovieId = 1,
                            CharacterName = "Capitán América",
                            DisplayOrder = 1
                        },
                        new
                        {
                            ActorId = 8,
                            MovieId = 5,
                            CharacterName = "Neo",
                            DisplayOrder = 1
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie", "mov");

                    b.HasData(
                        new
                        {
                            GenresId = 1,
                            MoviesId = 1
                        },
                        new
                        {
                            GenresId = 4,
                            MoviesId = 1
                        },
                        new
                        {
                            GenresId = 2,
                            MoviesId = 2
                        },
                        new
                        {
                            GenresId = 4,
                            MoviesId = 3
                        },
                        new
                        {
                            GenresId = 1,
                            MoviesId = 3
                        },
                        new
                        {
                            GenresId = 3,
                            MoviesId = 3
                        },
                        new
                        {
                            GenresId = 4,
                            MoviesId = 4
                        },
                        new
                        {
                            GenresId = 1,
                            MoviesId = 4
                        },
                        new
                        {
                            GenresId = 3,
                            MoviesId = 4
                        },
                        new
                        {
                            GenresId = 4,
                            MoviesId = 5
                        },
                        new
                        {
                            GenresId = 1,
                            MoviesId = 5
                        },
                        new
                        {
                            GenresId = 5,
                            MoviesId = 5
                        });
                });

            modelBuilder.Entity("CinemaHallMovie", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.CinemaHall", null)
                        .WithMany()
                        .HasForeignKey("CinemaHallsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaHall", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Cinema", "Cinema")
                        .WithMany("CinemaHalls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaOffer", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Cinema", null)
                        .WithOne("CinemaOffer")
                        .HasForeignKey("EFCoreMovies.Entities.CinemaOffer", "CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.MovieActor", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Actor", "Actor")
                        .WithMany("MoviesActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", "Movie")
                        .WithMany("MoviesActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Actor", b =>
                {
                    b.Navigation("MoviesActors");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Cinema", b =>
                {
                    b.Navigation("CinemaHalls");

                    b.Navigation("CinemaOffer");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Movie", b =>
                {
                    b.Navigation("MoviesActors");
                });
#pragma warning restore 612, 618
        }
    }
}
