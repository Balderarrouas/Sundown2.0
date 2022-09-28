using Moq;
using Sundown2._0.Controllers;
using Sundown2._0.Entities;
using Sundown2._0.ExceptionHandling.Exceptions;
using Sundown2._0.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
