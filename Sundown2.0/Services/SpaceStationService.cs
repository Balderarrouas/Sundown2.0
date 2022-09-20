using GeoCoordinatePortable;
using MoreLinq;
using Sundown2._0.Data;
using Sundown2._0.Entities;
using Sundown2._0.ExceptionHandling.Exceptions;
using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;



namespace Sundown2._0.Services
{
    public interface ISpaceStationService
    {
        Task<ClosestLandingFacility> Get();
    }


    public class SpaceStationService : ISpaceStationService
    {
        private Uri BaseAddress = new Uri("https://api.wheretheiss.at/");
        private HttpClient _httpClient;
        private ApplicationDbContext _applicationDbContext;
        

        public SpaceStationService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = BaseAddress;
            _applicationDbContext = context;
        }

        

        public async Task<ClosestLandingFacility> Get()
        {
            
            long unixTimestamp = ConvertDatetimeToUnixTimeStamp(DateTime.UtcNow);
            string APIURL = $"v1/satellites/25544/positions?timestamps={unixTimestamp}";
            var response = await _httpClient.GetAsync(APIURL);

            if (!response.IsSuccessStatusCode)
            {
                throw new CustomFetchFromApiException($"{BaseAddress}{APIURL} returned {response.StatusCode}");
            }

            var jsonResult = await response.Content.ReadAsStringAsync();           

            // Deserialize jsonResult
            var spaceStationList = JsonSerializer.Deserialize<List<SpaceStation>>(jsonResult);
            var spaceStation = spaceStationList.First();


            var issCoord = new GeoCoordinate(spaceStation.Latitude, spaceStation.Longitude);
                                             
            var europeCoord = new GeoCoordinate(55.68474022214539, 12.50971483525464);
            var chinaCoord = new GeoCoordinate(41.14962602664463, 119.33727554032843);
            var americaCoord = new GeoCoordinate(40.014407426017335, -103.68329704730307);
            var africaCoord = new GeoCoordinate(-21.02973667221353, 23.77076788325546);
            var australiaCoord = new GeoCoordinate(-33.00702098732439, 117.83314818861444);
            var indiaCoord = new GeoCoordinate(19.330540162912126, 79.14236662251713);
            var argentinaCoord = new GeoCoordinate(-34.050351176517886, -65.92682965568743);


            Dictionary<string, double> distanceDict = new Dictionary<string, double>();

            distanceDict.Add("Europe", issCoord.GetDistanceTo(europeCoord));
            distanceDict.Add("China", issCoord.GetDistanceTo(chinaCoord));
            distanceDict.Add("America", issCoord.GetDistanceTo(americaCoord));
            distanceDict.Add("Africa", issCoord.GetDistanceTo(africaCoord));
            distanceDict.Add("Australia", issCoord.GetDistanceTo(australiaCoord));
            distanceDict.Add("India", issCoord.GetDistanceTo(americaCoord));
            distanceDict.Add("Argentina", issCoord.GetDistanceTo(argentinaCoord));

            var landingSites = _applicationDbContext.LandingFacilities.ToList();

            var closestLanding = distanceDict.MinBy(kvp => kvp.Value);

            ClosestLandingFacility currentClosestLandingSite = new ClosestLandingFacility(closestLanding.First().Key, closestLanding.First().Value);
            
            foreach (var landingSiteItems in landingSites)
            {
                if (landingSiteItems.Name == currentClosestLandingSite.CountryName)
                {
                    currentClosestLandingSite.Latitude = landingSiteItems.Latitude;
                    currentClosestLandingSite.Longitude = landingSiteItems.Longitude;
                }
            }

            currentClosestLandingSite.CreatedAt = DateTime.UtcNow;

            _applicationDbContext.Add(currentClosestLandingSite);
            _applicationDbContext.SaveChanges();


            return currentClosestLandingSite;
         }

        // Helper Methods 
        public static long ConvertDatetimeToUnixTimeStamp(DateTime date)
        {
            var dateTimeOffset = new DateTimeOffset(date);
            var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();

            return unixDateTime;
        }


    }
}
