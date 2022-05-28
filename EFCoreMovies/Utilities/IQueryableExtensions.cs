namespace EFCoreMovies.Utilities
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, IPager pager, int recCount = -1)
        {
            int page = (pager.PageNumber ?? 0) < 1
                     ? 1
                     : pager.PageNumber.Value;
            int pageSize = (pager.PageSize ?? 0) < 1
                         ? 10
                         : pager.PageSize.Value;

            if (recCount > 0 && pageSize >= recCount)
                return query;

            if (recCount > 0)
            {
                int totalpages = (int)Math.Ceiling((decimal)recCount / (decimal)pageSize);
                page = page > totalpages ? totalpages : page;
            }

            return query.Skip((page - 1) * pageSize)
                        .Take(pageSize);
        }
    }
}
