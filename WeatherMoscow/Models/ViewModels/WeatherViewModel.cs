using System.Collections.Generic;

namespace WeatherMoscow.Models.ViewModels
{
    public class WeatherViewModel
    {
        public IEnumerable<Weather> Weathers { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}