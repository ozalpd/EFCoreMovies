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
    [Route("api/Cinemas")]
    public class CinemasController : AbstractMapperController
    {
        public CinemasController(AppDbContext context, IMapper mapper) : base(context, mapper) { }


        [HttpGet]
        public async Task<IEnumerable<CinemaDTO>> Get(string searchString, int page = 1, int pageSize = 2)
        {
            IQueryable<Cinema> query = dbContext.Cinemas;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a => a.Name.Contains(searchString));
            }

            int recCount = await query.CountAsync();
            var dtoQuery = query.OrderBy(a => a.Name)
                                .Paginate(page, pageSize, recCount)
                                .ProjectTo<CinemaDTO>(mapper.ConfigurationProvider);
            return await dtoQuery.ToListAsync();
        }
    }
}
