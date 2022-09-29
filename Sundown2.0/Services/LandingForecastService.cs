using Sundown2._0.Entities;
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
        Task<LandingTime> DetermineTimeOfLanding(ClosestLandingFacility closestLandingFacility);
        Task<WeatherForecast> GetWeatherForecast(ClosestLandingFacility closestLandingSite);
    }

    public class LandingForecastService : ILandingForecastService
    {

        private readonly Uri BaseAddress = new Uri("https://api.met.no/");
        private readonly HttpClient _httpClient;


        public LandingForecastService(HttpClient httpClient)          
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = BaseAddress;
        }



        public async Task<WeatherForecast> GetWeatherForecast(ClosestLandingFacility closestLandingSite)
        {
            var landingLat = closestLandingSite.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-us"));
            var landingLon = closestLandingSite.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-us"));

            var APIURL = $"weatherapi/locationforecast/2.0/compact?lat={landingLat}&lon={landingLon}";
            var response = await _httpClient.GetAsync(APIURL);

            if (!response.IsSuccessStatusCode)
            {
                throw new CustomFetchFromApiException($"{BaseAddress}{APIURL} returned {response.StatusCode}");
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonResult);

            return weatherForecast;
        }


        public async Task<LandingTime> DetermineTimeOfLanding(ClosestLandingFacility closestLandingFacility)
        {

            var weatherForecast = await GetWeatherForecast(closestLandingFacility);
            var timeseriesList = weatherForecast.properties.timeseries.OrderBy(timeseriesItem => timeseriesItem.data.instant.details.air_temperature);


            
            if (!timeseriesList.Any())
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
                        var timeOfLanding = new LandingTime(timeOfItem, item.data.instant.details.air_temperature);
                       
                        return timeOfLanding;
                    }                    
                }
            }                                 
            return null;
        }

       

    }
}
