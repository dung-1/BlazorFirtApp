namespace BlazorApp1.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
<<<<<<< HEAD
   
=======
>>>>>>> 7e2fb0bff8c1c90ba9839e522a766f0fd0b2bd04
}
