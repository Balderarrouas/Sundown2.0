using GeoCoordinatePortable;
using MoreLinq;
using Sundown2._0.Data;
using Sundown2._0.Entities;
using Sundown2._0.ExceptionHandling.Exceptions;
using Sundown2._0.Models;
using Sundown2._0.Utils;
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
        Task<ClosestLandingFacility> DetermineClosestLanding();
        Task<SpaceStation> GetIssLocation();
    }


    public class SpaceStationService : ISpaceStationService
    {

        private readonly Uri BaseAddress = new Uri("https://api.wheretheiss.at/");
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SpaceStationUtils _spaceStationUtils;
        

        public SpaceStationService(HttpClient httpClient, ApplicationDbContext context, SpaceStationUtils spaceStationUtils
            )
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = BaseAddress;
            _applicationDbContext = context;
            _spaceStationUtils = spaceStationUtils;
        }

        public async Task<SpaceStation> GetIssLocation()
        {
            // get current unix timestamp
            long unixTimestamp = ConvertDatetimeToUnixTimeStamp(DateTime.UtcNow);

            // call the iss api to get the current location
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

            return spaceStation;
        }

        public async Task<ClosestLandingFacility> DetermineClosestLanding()
        {            
            var iss = await GetIssLocation();

            var distanceDict = _spaceStationUtils.CreateCoordinateDictionary(iss);

            var closestLandingSite = _spaceStationUtils.SortDictionary(distanceDict);

            var landingSites = _applicationDbContext.LandingFacilities.ToList();

            foreach (var landingSiteItems in landingSites)
            {
                if (landingSiteItems.Name == closestLandingSite.CountryName)
                {
                    closestLandingSite.Latitude = landingSiteItems.Latitude;
                    closestLandingSite.Longitude = landingSiteItems.Longitude;
                    closestLandingSite.CreatedAt = DateTime.UtcNow;

                    _applicationDbContext.Add(closestLandingSite);
                    _applicationDbContext.SaveChanges();

                    return closestLandingSite;
                }
            }
            return null;
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
