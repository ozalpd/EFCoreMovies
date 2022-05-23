using EFCoreMovies.Entities;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class MoviesController : AbstractController
    {
        public MoviesController(AppDbContext context) : base(context) { }

        private IQueryable<Movie> GetMoviesQuery()
        {
            var query = dbContext.Movies
                                 //.AsNoTracking()
                                 .Include(m => m.Genres)
                                 .Include(m => m.CinemaHalls)
                                 .Include(m => m.MoviesActors).ThenInclude(ma => ma.Actor);
            return query;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var query = GetMoviesQuery();
            var movie = await query.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetList(string searchString, int page = 1, int pageSize = 2)
        {
            var query = GetMoviesQuery();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = from m in query
                        where m.Title.Contains(searchString)
                           || m.Genres.Any(g => g.Name.Contains(searchString))
                           || m.CinemaHalls.Any(ch => ch.Cinema.Name.Contains(searchString))
                           || m.MoviesActors.Any(ma => ma.Actor.Name.Contains(searchString))
                        select m;
            }

            int recCount = await query.CountAsync();
            return await query.OrderBy(g => g.Title)
                              .Paginate(page, pageSize, recCount)
                              .ToListAsync();
        }
    }
}