using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sundown2._0.Services
{
    public class LandingForecastService : ILandingForecastService
    {

        private readonly ISpaceStationService _spaceStationService;



        private Uri BaseAddress = new Uri("https://api.met.no/");
        private HttpClient _httpClient;


        public LandingForecastService(HttpClient httpClient, ISpaceStationService spaceStationService)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = BaseAddress;
            _spaceStationService = spaceStationService;
        }



        public async Task<LandingTime> Get()
        {

            

            var closestLanding = await _spaceStationService.Get();
            var landingLat = closestLanding.Latitude.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
            var landingLon = closestLanding.Longitude.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
            
            //NumberFormatInfo nfi = new NumberFormatInfo();
            //nfi.NumberDecimalSeparator = ".";
            //landingLat.ToString(nfi);
            //landingLon.ToString(nfi);

            string APIURL = $"weatherapi/locationforecast/2.0/compact?lat={landingLat}&lon={landingLon}";

            var response = await _httpClient.GetAsync(APIURL);
            var jsonResult = await response.Content.ReadAsStringAsync();


            var weatherForecast = JsonSerializer.Deserialize<Root>(jsonResult);

            // Sortere items fra timeseries by air_temp fra lavest til højest(default for .OrderBy)
            var timeseries = weatherForecast.properties.timeseries.OrderBy(timeseriesItem => timeseriesItem.data.instant.details.air_temperature);

            // Looper items
            foreach (var item in timeseries)
            {
                // Parser hvert items tid(fordi det er en string) til DateTimeOffset. out bruges til at få timeOfItem ud istedet for en boolean da TryParse ellers ville give true/false
                if (DateTimeOffset.TryParse(item.time, out DateTimeOffset timeOfItem)) {
                   
                    // For at bruge Compare metoden skal vi bruge noget at sammenligne med, udgangspunktet er nu og sammenligningspunktet er 24 timer ude i fremtiden (DateTimeOffset.now.AddHours(24))
                    var oneDayFromNow = DateTimeOffset.Now.AddHours(24);
                   
                    // Compare giver en int som representere om det er før, nu eller senere (-1,0,1) Derfor skal timeOffItem være før eller ens ift et døgn fremme
                    if(DateTimeOffset.Compare(timeOfItem, oneDayFromNow) <= 0)
                    {
                        // laver et objekt af LandingTime og sætter properties til de rigtige værdier
                        LandingTime landingTime = new LandingTime(timeOfItem, item.data.instant.details.air_temperature);
                      
                        // returnere objektet fra loopet og return afbryder resten af metoden
                        return landingTime;
                    }
                    
                }
            }
            
            //var timeseriesItems = weatherForecast.properties.timeseries.ToList();
            //var date = timeseriesItems[0].time;
            //var temp = timeseriesItems[0].data.instant.details.air_temperature;
            //// something[0].data.instant.details.air_t
            

            // returnere null da vi bruger et reutn statement et andet sted
            return null;
        }
    }
}
