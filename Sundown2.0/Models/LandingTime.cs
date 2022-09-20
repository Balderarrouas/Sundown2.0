using Sundown2._0.Entities;
using System;

namespace Sundown2._0.Models
{
    public class LandingTime
    {

        // public int Id { get; set; }
        public DateTimeOffset BestLandingTime { get; }

        public double LowestLandingTemp { get; set; }
        public ClosestLandingFacility ClosestLandingFacility { get; set; }


        public LandingTime(DateTimeOffset bestLandingTime, double lowestLandingTemp, ClosestLandingFacility closest)
        {
            BestLandingTime = bestLandingTime;
            LowestLandingTemp = lowestLandingTemp;
            ClosestLandingFacility = closest;
        }
    }
}
