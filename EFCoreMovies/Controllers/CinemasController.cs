using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Entities;
using EFCoreMovies.Models;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/Cinemas")]
    public class CinemasController : AbstractMapperController
    {
        public CinemasController(AppDbContext context, IMapper mapper) : base(context, mapper) { }


        [HttpGet]
        public async Task<IEnumerable<CinemaDTO>> Get(string searchString, int page = 1, int pageSize = 2,
            double? latitude = null, double? longitude = null, int maxDistance = 2500)
        {
            IQueryable<Cinema> query = dbContext.Cinemas;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a => a.Name.Contains(searchString));
            }

            IQueryable<CinemaDTO> dtoQuery = null;
            if (latitude != null && longitude != null)
            {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var visitorLocation = geometryFactory.CreatePoint(new Coordinate(longitude.Value, latitude.Value));
                query = query.OrderBy(c => c.Location.Distance(visitorLocation));
                if (maxDistance > 5)
                {
                    query = query.Where(c => c.Location.IsWithinDistance(visitorLocation, maxDistance));
                }

                int recCount = await query.CountAsync();
                dtoQuery = query.Paginate(page, pageSize, recCount)
                                .Select(c => new CinemaDTO
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Latitude = c.Location.Y,
                                    Longitude = c.Location.X,
                                    Distance = (int?)Math.Round(c.Location.Distance(visitorLocation)),
                                    TicketPrice = c.TicketPrice
                                });
            }
            else
            {
                int recCount = await query.CountAsync();
                dtoQuery = query.OrderBy(a => a.Name)
                                .Paginate(page, pageSize, recCount)
                                .ProjectTo<CinemaDTO>(mapper.ConfigurationProvider);
            }
            return await dtoQuery.ToListAsync();
        }
    }
}
