using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Entities;
using EFCoreMovies.Models;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class MoviesController : AbstractMapperController
    {
        public MoviesController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        private IQueryable<Movie> GetMoviesQuery()
        {
            var query = dbContext.Movies
                                  .AsNoTracking()
                                  .Include(m => m.Genres)
                                  .Include(m => m.MoviesActors).ThenInclude(ma => ma.Actor);
            return query;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieFullDTO>> Get(int id)
        {
            var query = GetMoviesQuery();
            var movie = await query.Include(m => m.CinemaHalls).ThenInclude(ch => ch.Cinema)
                                   .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<MovieFullDTO>(movie);
            dto.Cinemas = dto.Cinemas.DistinctBy(c => c.Id).ToList();
            return dto;
        }

        [HttpGet("byProjection")]
        public async Task<ActionResult> GetByProjection()
        {
            var query = GetMoviesQuery().GroupBy(m => m.InCinemas)
                                        .Select(g => new
                                        {
                                            InCinemas = g.Key,
                                            Count = g.Count(),
                                            Movies = mapper.Map<List<MovieListDTO>>(g.ToList())
                                        });
            var groupedMovies = await query.ToListAsync();

            return Ok(groupedMovies);
        }

        [HttpGet("Light{id:int}")]
        public async Task<ActionResult> GetLight(int id)
        {
            var query = GetMoviesQuery();
            var movie = await query.ProjectTo<MovieFullDTO>(mapper.ConfigurationProvider)
                                   .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Actors = movie.Actors.Select(a => a.Name).OrderBy(n => n).ToList(),
                Cinemas = movie.Cinemas.DistinctBy(c => c.Id).Select(c => c.Name).OrderBy(n => n).ToList(),
                Genres = movie.Genres.Select(g => g.Name).OrderBy(n => n).ToList()
            });
        }

        [HttpGet]
        public async Task<IEnumerable<MovieListDTO>> GetList(string searchString, int page = 1, int pageSize = 2)
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
                              .ProjectTo<MovieListDTO>(mapper.ConfigurationProvider)
                              .ToListAsync();
        }
    }
}