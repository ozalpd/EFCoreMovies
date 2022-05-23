namespace EFCoreMovies.Utilities
{
    public interface IPager
    {
        int? PageNumber { get; set; }
        int? PageSize { get; set; }
    }
}
