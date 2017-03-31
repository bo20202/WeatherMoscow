namespace WeatherMoscow.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WeatherContext : DbContext
    {
        public WeatherContext()
            : base("name=Weather")
        {
        }


         public DbSet<Weather> WeatherObjects { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int AirTemp { get; set; }
        public int Moisture { get; set; }
        public int DewPoint { get; set; }

        public int Pressure { get; set; }

        public string WindDir { get; set; }
        public int? WindSpeed { get; set; }

        public int Cloudness { get; set; }
        public int CloudBase { get; set; }
        public int HorizontalVisibility { get; set; }

        public string WeatherConditions { get; set; }

    }
}