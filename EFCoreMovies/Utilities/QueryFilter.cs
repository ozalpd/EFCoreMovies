namespace EFCoreMovies.Utilities
{
    public class QueryFilter : IPager
    {
        public string SearchString { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
