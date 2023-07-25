namespace LongRunningWebAPI
{
    /// <summary>
    /// WeatherForecast
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Forecast Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Temperature in C
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Temperature in F
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Forecast Summary
        /// </summary>
        public string? Summary { get; set; }
    }
}