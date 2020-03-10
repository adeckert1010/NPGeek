using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int LowTemp { get; set; }
        public int HighTemp { get; set; }
        public string ForecastString { get; set; }

        public string isHot { get; set; }
        public bool isCold { get; set; }
        public bool isTwentySpread { get; set; }



        public Dictionary<string, string> WeatherAdvisoryStrings = new Dictionary<string, string>
        {
            {"snow", "Pack snowshoes!" },
            {"rain", "Pack rain gear and wear waterproof shoes." },
            {"thunderstorms", "Seek shelter and avoid hiking on exposed ridges" },
            {"sun", "Pack sunblock!" }
        };

        public string GetAdvisory()
        {
            if (HighTemp - LowTemp > 20)
            {
                return "Wear breathable layers.";
            }
            if (HighTemp > 75)
            {
                return "Bring an extra gallon of water!";
            }
            if(LowTemp < 20)
            {
                return "Be careful you don't freeze to death. That would suck.";
            }
            return "";
            
        }


    }
}
