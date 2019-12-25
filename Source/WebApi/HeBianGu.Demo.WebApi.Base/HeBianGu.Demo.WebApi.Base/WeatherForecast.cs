using System;

namespace HeBianGu.Demo.WebApi.Base
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }


        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
    }
}
