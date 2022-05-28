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
        public async Task<IEnumerable<CinemaDTO>> Get([FromQuery] GeoQueryFilter filter)
        {
            IQueryable<Cinema> query = dbContext.Cinemas;
            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                query = query.Where(a => a.Name.Contains(filter.SearchString));
            }

            IQueryable<CinemaDTO> dtoQuery = null;
            if (filter.Latitude != null && filter.Longitude != null)
            {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var visitorLocation = geometryFactory.CreatePoint(new Coordinate(filter.Longitude.Value, filter.Latitude.Value));
                query = query.OrderBy(c => c.Location.Distance(visitorLocation));
                if ((filter.MaxDistance ?? 0) > 5)
                {
                    query = query.Where(c => c.Location.IsWithinDistance(visitorLocation, filter.MaxDistance.Value));
                }

                int recCount = await query.CountAsync();
                dtoQuery = query.Paginate(filter, recCount)
                                .Select(c => new CinemaDTO
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Latitude = c.Location != null ? c.Location.Y : null,
                                    Longitude = c.Location != null ? c.Location.X : null,
                                    Distance = c.Location != null ? (int?)Math.Round(c.Location.Distance(visitorLocation)) : null,
                                    TicketPrice = c.TicketPrice
                                });
            }
            else
            {
                int recCount = await query.CountAsync();
                dtoQuery = query.OrderBy(a => a.Name)
                                .Paginate(filter, recCount)
                                .ProjectTo<CinemaDTO>(mapper.ConfigurationProvider);
            }
            return await dtoQuery.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CinemaThinDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(e => e.Value.Errors.Count > 0);
                return BadRequest(errors);
            }
            Cinema cinema = null;
            if (dto.Id > 0)
            {
                cinema = await dbContext.Cinemas
                                        .AsTracking()
                                        .FirstOrDefaultAsync(c => c.Id == dto.Id);
                mapper.Map(dto, cinema);
            }
            else
            {
                cinema = mapper.Map<Cinema>(dto);
                dbContext.Cinemas.Add(cinema);
            }

            if (dto.Longitude > 0 && dto.Latitude > 0)
            {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                cinema.Location = geometryFactory.CreatePoint(
                    new Coordinate(dto.Latitude.Value, dto.Longitude.Value));
            }
            else
            {
                cinema.Location = null;
            }

            await dbContext.SaveChangesAsync();
            return Ok(mapper.Map<CinemaThinDTO>(cinema));
        }
    }
}
