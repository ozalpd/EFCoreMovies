namespace EFCoreMovies.Utilities
{
    public class GeoFilterParams : FilterParams
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? MaxDistance { get; set; } 
    }
}
