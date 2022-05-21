using EFCoreMovies.Entities;
using EFCoreMovies.Entities.DTOs;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/Actors")]
    public class ActorsController : AbstractController
    {
        public ActorsController(AppDbContext context) : base(context) { }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get(string searchString, int page = 1, int pageSize = 2)
        {
            IQueryable<Actor> query = dbContext.Actors;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a => a.Name.Contains(searchString));
            }

            int recCount = await query.CountAsync();
            var dtoQuery = query.OrderBy(a => a.Name)
                                .Paginate(page, pageSize, recCount)
                                .Select(a => new ActorDTO
                                {
                                    Id = a.Id,
                                    Name = a.Name,
                                    DateOfBirth = a.DateOfBirth
                                });
            return await dtoQuery.ToListAsync();
        }
    }
}
