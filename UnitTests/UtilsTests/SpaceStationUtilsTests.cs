﻿using FluentAssertions;
using GeoCoordinatePortable;
using Moq;
using MoreLinq;
using Sundown2._0.Entities;
using Sundown2._0.Models;
using Sundown2._0.Services;
using Sundown2._0.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UtilsTests
{
    public class SpaceStationUtilsTests
    {
        
        [Fact]
        public void SortDictionary_Should_Return_Shortest_Distance_Test()
        {
            // arrange 

            var spaceStation = new SpaceStation { Name = "test", Altitude = 1, Latitude = 15.56543, Longitude = 112.654346, Daynum = 1, Footprint = 1, Id = 1, SolarLat = 1, SolarLon = 1, Timestamp = 1, Units = "", Velocity = 1, Visibility = "" };
            var sut = new SpaceStationUtils();

            // act 
            
            var coordDictionary = sut.CreateCoordinateDictionary(spaceStation);
            var result = sut.SortDictionary(coordDictionary);

            

            // assert
            foreach (var landingFacility in coordDictionary)
            {
                if (result.CountryName != landingFacility.Key)
                    Assert.True(result.CurrentDistanceInMeters < landingFacility.Value);
            }







        }
       

    }
}
