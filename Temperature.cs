namespace WeatherDataLibrary
{
    public class Temperature
    {
        public float Temp { get; }
        public float FeelsLikeTemp { get; }
        public float TempMin { get; }
        public float TempMax { get; }

        internal Temperature(float temp, float feels_like, float temp_min, float temp_max)
        {
            Temp = temp;
            FeelsLikeTemp = feels_like;
            TempMin = temp_min;
            TempMax = temp_max;
        }
    }
}