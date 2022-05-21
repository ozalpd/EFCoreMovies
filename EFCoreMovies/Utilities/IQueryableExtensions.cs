namespace EFCoreMovies.Utilities
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize, int recCount = -1)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;
            if (recCount > 0)
            {
                int totalpages = recCount / pageSize;
                page = page > totalpages ? totalpages : page;
            }

            return query.Skip((page - 1) * pageSize)
                        .Take(pageSize);
        }
    }
}
