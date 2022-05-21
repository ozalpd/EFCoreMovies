using EFCoreMovies.Entities.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Actor : ActorDTO
    {
        public Actor()
        {
            MoviesActors = new HashSet<MovieActor>();
        }

        public string Biography { get; set; }


        public ICollection<MovieActor> MoviesActors { get; set; }
    }
}
