using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        public AbstractController(AppDbContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
        }
        protected readonly AppDbContext dbContext;
        protected readonly IMapper mapper;

    }
}
