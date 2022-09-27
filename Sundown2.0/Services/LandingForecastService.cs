using AutoMapper;
using Sundown2._0.Data;
using Sundown2._0.ExceptionHandling.Exceptions;
using Sundown2._0.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sundown2._0.Services
{
    public interface ILandingForecastService
    {
        Task<LandingTime> DetermineTimeOfLanding();
    }

    public class LandingForecastService : ILandingForecastService
    {

        private readonly ISpaceStationService _spaceStationService;
        private readonly Uri BaseAddress = new Uri("https://api.met.no/");
        private readonly HttpClient _httpClient;


        public LandingForecastService(HttpClient httpClient, ISpaceStationService spaceStationService)          
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = BaseAddress;
            _spaceStationService = spaceStationService;
        }



        public async Task<IOrderedEnumerable<TimeseriesItem>> GetWeatherForeCast()
        {
            var closestLandingSite = await _spaceStationService.DetermineClosestLanding();
            var landingLat = closestLandingSite.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-us"));
            var landingLon = closestLandingSite.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-us"));

            string APIURL = $"weatherapi/locationforecast/2.0/compact?lat={landingLat}&lon={landingLon}";
            var response = await _httpClient.GetAsync(APIURL);

            if (!response.IsSuccessStatusCode)
            {
                throw new CustomFetchFromApiException($"{BaseAddress}{APIURL} returned {response.StatusCode}");
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonResult);
            var timeseriesList = weatherForecast.properties.timeseries.OrderBy(timeseriesItem => timeseriesItem.data.instant.details.air_temperature);

            return timeseriesList;
        }


        public async Task<LandingTime> DetermineTimeOfLanding()
        {

            var timeseriesList = await GetWeatherForeCast();
            var closestLandingSite = await _spaceStationService.DetermineClosestLanding();


            if (timeseriesList.Count() == 0)
            {
                throw new CustomApplicationException("No items added to timeseriesList");
            }
            
            foreach (var item in timeseriesList)
            {                
                if (DateTimeOffset.TryParse(item.time, out DateTimeOffset timeOfItem)) 
                {                   
                    var oneDayFromNow = DateTimeOffset.Now.AddHours(24);
                   
                    if(DateTimeOffset.Compare(timeOfItem, oneDayFromNow) <= 0)
                    {
                        var timeOfLanding = new LandingTime(timeOfItem, item.data.instant.details.air_temperature, closestLandingSite);
                       
                        return timeOfLanding;
                    }                    
                }
            }                                 
            return null;
        }

       

    }
}
