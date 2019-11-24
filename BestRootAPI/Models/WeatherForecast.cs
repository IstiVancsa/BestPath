using System;
using System.Collections.Generic;

namespace Models
{
    public class WeatherForecast:BaseModel
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public override IList<BaseModel> CreateSeeds(int numberOfSeeds)
        {
            throw new NotImplementedException();
        }
    }
}
