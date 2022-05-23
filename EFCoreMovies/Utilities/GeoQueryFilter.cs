namespace EFCoreMovies.Utilities
{
    public class GeoQueryFilter : QueryFilter
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? MaxDistance { get; set; } 
    }
}
