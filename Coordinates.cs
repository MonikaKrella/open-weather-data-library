namespace WeatherDataLibrary
{
    public class Coordinates
    {
        public float Lon { get; }
        public float Lat { get; }

        internal Coordinates(float lon, float lat)
        {
            Lon = lon;
            Lat = lat;
        }
    }
}