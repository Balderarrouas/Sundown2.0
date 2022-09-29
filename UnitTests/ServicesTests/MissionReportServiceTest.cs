using Moq;
using Sundown2._0.ExceptionHandling.Exceptions;
using Sundown2._0.Services;
using System;
using Xunit;

namespace UnitTests.ServicesTests
{
    public class MissionReportServiceTest
    {

        
        // tester kun mock
        [Fact]
        public void GetById_Should_fail_with_wrong_id()
        {
            // arrange
            var mock = new Mock<IMissionReportService>();            
            var id = Guid.NewGuid();
            
            mock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new CustomNotFoundException());

            // act
            // Assert
            Assert.Throws<CustomNotFoundException>(() => mock.Object.GetById(id));
            
        }
         
        


        

    }
}
