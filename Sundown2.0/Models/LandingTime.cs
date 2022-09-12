using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Models
{
    public class LandingTime
    {

        public int Id { get; set; }
        public DateTimeOffset BestLandingTime { get; }

        public double LowestLandingTemp { get; set; }


        public LandingTime(DateTimeOffset bestLandingTime, double lowestLandingTemp)
        {
            BestLandingTime = bestLandingTime;
            LowestLandingTemp = lowestLandingTemp;
        }
    }
}
