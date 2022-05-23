namespace EFCoreMovies.Utilities
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, IPager pager, int recCount = -1)
        {
            int page = pager.PageNumber ?? 1;
            int pageSize = pager.PageSize ?? 10;

            if (recCount > 0)
            {
                int totalpages = recCount / pageSize;
                page = page > totalpages ? totalpages : page;
            }
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;

            return query.Skip((page - 1) * pageSize)
                        .Take(pageSize);
        }
    }
}
