using Microsoft.AspNetCore.Mvc;

namespace EFCoreMovies.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        public AbstractController(AppDbContext context)
        {
            dbContext = context;
        }
        protected readonly AppDbContext dbContext;

    }
}
