using EFCoreMovies.Models;
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
        public string InstagramURL { get; set; }
        public string TwitterURL { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (DateOfBirth == null)
                    return null;

                var today = DateTime.Now.Date;
                int age = today.Year - DateOfBirth.Value.Year;
                if (today.DayOfYear < DateOfBirth.Value.DayOfYear)
                    age--;

                return age;
            }
        }
        public ICollection<MovieActor> MoviesActors { get; set; }
    }
}
