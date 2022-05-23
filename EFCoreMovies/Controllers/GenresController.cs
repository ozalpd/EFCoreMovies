using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.DTOs;
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
        public async Task<IEnumerable<GenreDTO>> Get(string searchString, int page = 1, int pageSize = 2)
        {
            IQueryable<Genre> query = dbContext.Genres.AsNoTracking();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = from g in query
                        where g.Name.Contains(searchString)
                           || g.Movies.Any(m => m.Title.Contains(searchString))
                        select g;
            }

            int recCount = await query.CountAsync();
            query = query.OrderBy(g => g.Name)
                         .Paginate(page, pageSize, recCount);
  
            return await query.ProjectTo<GenreDTO>(mapper.ConfigurationProvider)
                              .ToListAsync();
        }
    }
}
