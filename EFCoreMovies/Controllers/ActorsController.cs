using EFCoreMovies.Entities;
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
        public async Task<IEnumerable<Actor>> Get(string searchString, int page = 1, int pageSize = 2)
        {
            IQueryable<Actor> query = dbContext.Actors;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a => a.Name.Contains(searchString));
            }

            int recCount = await query.CountAsync();
            return await query.OrderBy(a => a.Name)
                              .Paginate(page, pageSize, recCount)
                              //.AsNoTracking()
                              .ToListAsync();
        }
    }
}
