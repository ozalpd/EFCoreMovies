using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        public GenresController(AppDbContext context)
        {
            dbContext = context;
        }
        private readonly AppDbContext dbContext;

        [HttpGet]
        public async Task<IEnumerable<Genre>> Get(string searchString, int page = 1, int pageSize = 2)
        {
            IQueryable<Genre> query = dbContext.Genres;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = from g in query
                        where g.Name.Contains(searchString)
                           || g.Movies.Any(m => m.Title.Contains(searchString))
                        select g;
                //.Where(g => );
            }

            //int recCount = await query.CountAsync();
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;
            return await query.OrderBy(g => g.Name)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .AsNoTracking()
                              .ToListAsync();
        }
    }
}
