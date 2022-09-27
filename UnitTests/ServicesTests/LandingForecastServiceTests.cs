using Moq;
using Sundown2._0.Entities;
using Sundown2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServicesTests
{
    public class LandingForecastServiceTests
    {


        [Fact]
        public async void DetermineTimeOfLanding_Should_Return_Lowest_Temp_Test()
        {
            // arrange 
            //var sut = new Mock<LandingForecastService>();
            var httpClient = new Mock<HttpClient>();
            var mock = new Mock<ISpaceStationService>();
            var sut = new LandingForecastService(httpClient.Object, mock.Object);
            // mock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new CustomNotFoundException());
            var closest = new ClosestLandingFacility("Dk", 5000);

            mock.Setup(x => x.DetermineClosestLanding()).Returns(Task.FromResult(closest));


            // act
            var timeOfLanding = await sut.DetermineTimeOfLanding();
            var forecast = await sut.GetWeatherForeCast();
                //sut.GetWeatherForeCast();
            

            // assert
            foreach (var timeSeriesItemitem in forecast)
            {

            }

        }


    }
}
