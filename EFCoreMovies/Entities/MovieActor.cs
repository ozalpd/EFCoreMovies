using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities
{
    public class MovieActor
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }


        [MaxLength(200)]
        public string CharacterName { get; set; }

        public int DisplayOrder { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
