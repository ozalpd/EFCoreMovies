using AutoMapper;

namespace EFCoreMovies.Controllers
{
    public class AbstractMapperController : AbstractController
    {
        public AbstractMapperController(AppDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
        protected readonly IMapper mapper;
    }
}
