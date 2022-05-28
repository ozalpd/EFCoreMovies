namespace EFCoreMovies.Utilities
{
    public class FilterParams : IPager
    {
        public string SearchString { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
