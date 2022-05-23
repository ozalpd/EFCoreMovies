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
    [Route("api/Actors")]
    public class ActorsController : AbstractMapperController
    {
        public ActorsController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get([FromQuery] QueryFilter filter)
        {
            IQueryable<Actor> query = dbContext.Actors;
            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                query = query.Where(a => a.Name.Contains(filter.SearchString));
            }

            int recCount = await query.CountAsync();
            var dtoQuery = query.OrderBy(a => a.Name)
                                .Paginate(filter, recCount)
                                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider);
            /*We are using ProjectTo extension method of AutoMapper
             *instead of below part
                                .Select(a => new ActorDTO
                                {
                                    Id = a.Id,
                                    Name = a.Name,
                                    DateOfBirth = a.DateOfBirth
                                });
            */
            return await dtoQuery.ToListAsync();
        }
    }
}
