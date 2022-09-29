using Sundown2._0.Entities;
using Sundown2._0.Services;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace UnitTests.ServicesTests
{
    public class LandingForecastServiceTests
    {


        [Fact]
        public async void DetermineTimeOfLanding_Should_Return_Lowest_Temp_Test()
        {
            // arrange 
            var _httpClient = new HttpClient();
            var productValue = new ProductInfoHeaderValue("Sundown", "2.0");
            var commentValue = new ProductInfoHeaderValue("(+https://localhost:44302/api/landingforecast)");

            _httpClient.DefaultRequestHeaders.UserAgent.Add(productValue);
            _httpClient.DefaultRequestHeaders.UserAgent.Add(commentValue);



            var sut = new LandingForecastService(_httpClient);
            var closest = new ClosestLandingFacility("Dk", 5000, 55.68474022214539, 12.50971483525464);


            // act

            var forecast = await sut.GetWeatherForecast(closest);
            var timeOfLanding = await sut.DetermineTimeOfLanding(closest);
            var oneDayList = forecast.properties.timeseries.ToList();
            var newList = oneDayList.Take(24);
            

            // assert

            foreach (var item in newList)
            {
                Assert.True(timeOfLanding.LowestLandingTemp <= item.data.instant.details.air_temperature);
                
            }

        }


    }
}
