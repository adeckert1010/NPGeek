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

        public int ConvertHighTempToCelcius(int HighTemp)
        {
            int highCTemp = (HighTemp - 32) * 5 / 9;
            return highCTemp;
        }

        public int ConvertLowTempToCelcius(int LowTemp)
        {
            int lowCTemp = (LowTemp - 32) * 5 / 9;
            return lowCTemp;
        }

        public int ConvertHighCTempToFarenheit()
        {
            return HighTemp;
        }

        public int ConvertLowCTempToFarenheit()
        {
            return LowTemp;
        }
    }
}
