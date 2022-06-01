using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities.Configs
{
    public static class SeedSamplePosts
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var ozge = new Person { Id = 1, Name = "Ozge" };
            var wolf = new Person { Id = 2, Name = "Lone Wolf" };
            var sebnem = new Person { Id = 3, Name = "Shebnem" };
            var nurettin = new Person { Id = 4, Name = "Nurettin" };


            var postArwenAragorn = new Post
            {
                Id = 1,
                SenderId = ozge.Id,
                Subject = "Arwen and Aragorn",
                Body = "When Arwen and Aragorn met first time Aragorn was 20 and Arwen was 2710 years old." +
                " Don't you think they felt generational gap between each others? How could they handle it?"
            };
            var postAragorn = new Post
            {
                Id = 2,
                SenderId = wolf.Id,
                ParentPostId = postArwenAragorn.Id,
                Subject = "Re: Arwen and Aragorn",
                Body = "Aragorn had wisdom of thousands years so they should felt as they were in same generation."
            };
            Post hello = new Post
            {
                Id = 3,
                SenderId = nurettin.Id,
                Subject = "Hello",
                Body = "Hello I'm new around here."
            };
            Post coupon = new Post
            {
                Id = 4,
                SenderId = wolf.Id,
                Subject = "Coupons",
                Body = "Hello, I'm looking for discount coupons for Top Gun 2 movie." +
                " Anyone can help me?"
            };
            Post couponreply = new Post
            {
                Id = 5,
                SenderId = sebnem.Id,
                Subject = "Re:Coupons",
                Body = "I googled two hours ago, couldn't find any :-("
            };

            var postFiction = new Post
            {
                Id = 6,
                SenderId = sebnem.Id,
                ParentPostId = postAragorn.Id,
                Subject = "Re: Arwen and Aragorn",
                Body = "They are fictious characters of Tolkien." +
                " I don't think he used this level of complex details in his fictions."
            };

            modelBuilder.Entity<Person>().HasData(ozge, wolf, sebnem, nurettin);
            modelBuilder.Entity<Post>().HasData(postArwenAragorn, postAragorn, hello, postFiction, coupon, couponreply);
        }

    }
}
