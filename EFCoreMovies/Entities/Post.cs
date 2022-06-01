using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public int SenderId { get; set; }
        public Person Sender { get; set; }

        public int? ParentPostId { get; set; }

        [ForeignKey(nameof(ParentPostId))]
        public Post ParentPost { get; set; }

        [InverseProperty(nameof(ParentPost))]
        public List<Post> SubPosts { get; set; }
    }
}
