﻿using EFCoreMovies.Entities;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/Genres")]
    public class GenresController : AbstractController
    {
        public GenresController(AppDbContext context) : base(context) { }

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
            }

            int recCount = await query.CountAsync();
            return await query.OrderBy(g => g.Name)
                              .Paginate(page, pageSize, recCount)
                              //.AsNoTracking()
                              .ToListAsync();
        }
    }
}
