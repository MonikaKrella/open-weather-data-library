namespace WeatherDataLibrary
{
    public class WeatherData
    {
        public Coordinates Coordinates { get; }
        public Wind Wind { get; }
        public Temperature Temperature { get; }

        internal WeatherData(Coordinates coord, Wind wind, Temperature main)
        {
            Coordinates = coord;
            Wind = wind;
            Temperature = main;
        }
    }
}