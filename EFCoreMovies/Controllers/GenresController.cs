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
    [Route("api/Genres")]
    public class GenresController : AbstractMapperController
    {
        public GenresController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        [HttpGet]
        public async Task<IEnumerable<GenreDTO>> Get([FromQuery] QueryFilter filter)
        {
            IQueryable<Genre> query = dbContext.Genres.AsNoTracking();
            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                query = from g in query
                        where g.Name.Contains(filter.SearchString)
                           || g.Movies.Any(m => m.Title.Contains(filter.SearchString))
                        select g;
            }

            int recCount = await query.CountAsync();
            query = query.OrderBy(g => g.Name)
                         .Paginate(filter, recCount);

            return await query.ProjectTo<GenreDTO>(mapper.ConfigurationProvider)
                              .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenreThinDTO genre)
        {
            if (ModelState.IsValid)
            {
                var ent = mapper.Map<Genre>(genre);
                dbContext.Genres.Add(ent);
                await dbContext.SaveChangesAsync();
                return Ok(mapper.Map<GenreThinDTO>(ent));
            }
            else
            {
                var errors = ModelState.Where(e => e.Value.Errors.Count > 0);
                return BadRequest(errors);
            }
        }

        [HttpPost("multiple")]
        public async Task<ActionResult> Post(GenreThinDTO[] genre)
        {
            if (ModelState.IsValid)
            {
                var entArray = mapper.Map<Genre[]>(genre);
                await dbContext.AddRangeAsync(entArray);
                await dbContext.SaveChangesAsync();
                return Ok(mapper.Map<GenreThinDTO[]>(entArray));
            }
            else
            {
                var errors = ModelState.Where(e => e.Value.Errors.Count > 0);
                return BadRequest(errors);
            }
        }
    }
}
