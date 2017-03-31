namespace WeatherMoscow.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;

    public class WeatherContext : DbContext
    {
        public WeatherContext()
            : base("name=Weather")
        {
        }


         public DbSet<Weather> Weathers { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Display(Name = "Время")]
        public TimeSpan Time { get; set; }

        [Display(Name = "Температура")]
        public double? AirTemp { get; set; }
        [Display(Name = "Влажность")]
        public double? Moisture { get; set; }
        [Display(Name = "Точка росы")]
        public double? DewPoint{ get; set; }
        
        [Display(Name = "Давление")]
        public int? Pressure { get; set; }

        [Display(Name = "Направление ветра")]
        public string WindDir { get; set; }
        [Display(Name = "Скорость ветра")]
        public int? WindSpeed { get; set; }

        [Display(Name = "Облачность")]
        public int? Cloudness { get; set; }
        [Display(Name = "Нижняя граница облачности")]
        public int? CloudBase { get; set; }
        [Display(Name = "Горизонтальная видимость")]
        public int? HorizontalVisibility { get; set; }

        [Display(Name = "Погодные условия")]
        public string WeatherConditions { get; set; }

    }
}