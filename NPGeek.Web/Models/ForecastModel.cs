using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class ForecastModel
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public Dictionary<string, string> Instructions = new Dictionary<string, string>
        {
            {"snow", "Remember to pack your snowshoes!" },
            {"rain", "Remember to bring rain gear and waterproof shoes!" },
            {"thunderstorms", "Seek shelter and avoid hiking on exposed ridges!" },
            {"sunny", "Remember your sunblock!" },
            {"partly cloudy", "Enjoy your day!" },
            {"cloudy", "Every cloud is a silver lining!" }
        };
    }
}