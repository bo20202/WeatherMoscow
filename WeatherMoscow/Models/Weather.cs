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
        
        [Display(Name = "����")]
        public DateTime Date { get; set; }
        [Display(Name = "�����")]
        public TimeSpan Time { get; set; }

        [Display(Name = "�����������")]
        public double? AirTemp { get; set; }
        [Display(Name = "���������")]
        public double? Moisture { get; set; }
        [Display(Name = "����� ����")]
        public double? DewPoint{ get; set; }
        
        [Display(Name = "��������")]
        public int? Pressure { get; set; }

        [Display(Name = "����������� �����")]
        public string WindDir { get; set; }
        [Display(Name = "�������� �����")]
        public int? WindSpeed { get; set; }

        [Display(Name = "����������")]
        public int? Cloudness { get; set; }
        [Display(Name = "������ ������� ����������")]
        public int? CloudBase { get; set; }
        [Display(Name = "�������������� ���������")]
        public int? HorizontalVisibility { get; set; }

        [Display(Name = "�������� �������")]
        public string WeatherConditions { get; set; }

    }
}