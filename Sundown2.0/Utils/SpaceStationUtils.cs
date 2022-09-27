using GeoCoordinatePortable;
using MoreLinq;
using Sundown2._0.Data;
using Sundown2._0.Entities;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Utils
{
    


    public class SpaceStationUtils
    {

        

        // TODO make dynamic
        public Dictionary<string, double> CreateCoordinateDictionary(SpaceStation spacestation)
        {
            var issCoord = new GeoCoordinate(spacestation.Latitude, spacestation.Longitude);
          
            var europeCoord = new GeoCoordinate(55.68474022214539, 12.50971483525464);
            var chinaCoord = new GeoCoordinate(41.14962602664463, 119.33727554032843);
            var americaCoord = new GeoCoordinate(40.014407426017335, -103.68329704730307);
            var africaCoord = new GeoCoordinate(-21.02973667221353, 23.77076788325546);
            var australiaCoord = new GeoCoordinate(-33.00702098732439, 117.83314818861444);
            var indiaCoord = new GeoCoordinate(19.330540162912126, 79.14236662251713);
            var argentinaCoord = new GeoCoordinate(-34.050351176517886, -65.92682965568743);

            // create dictionary with distances from the iss to all landing facilities
            var dictionary = new Dictionary<string, double>();

            dictionary.Add("Europe", issCoord.GetDistanceTo(europeCoord));
            dictionary.Add("China", issCoord.GetDistanceTo(chinaCoord));
            dictionary.Add("America", issCoord.GetDistanceTo(americaCoord));
            dictionary.Add("Africa", issCoord.GetDistanceTo(africaCoord));
            dictionary.Add("Australia", issCoord.GetDistanceTo(australiaCoord));
            dictionary.Add("India", issCoord.GetDistanceTo(indiaCoord));
            dictionary.Add("Argentina", issCoord.GetDistanceTo(argentinaCoord));

            return dictionary;
        }

        public ClosestLandingFacility SortDictionary(Dictionary<string, double> dictionary)
        {

            var orderedDistances = dictionary.MinBy(kvp => kvp.Value);
            var closestLandingSite = new ClosestLandingFacility(orderedDistances.First().Key, orderedDistances.First().Value);

            return closestLandingSite;
        }





    }
}
