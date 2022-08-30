using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sundown2._0.Services
{
    public class SpaceStationService : ISpaceStationService
    {
        private Uri BaseAddress = new Uri("https://api.wheretheiss.at/");
        private HttpClient _httpClient;
        

        public SpaceStationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = BaseAddress;
        }

        public static long ConvertDatetimeToUnixTimeStamp(DateTime date)
        {
            var dateTimeOffset = new DateTimeOffset(date);
            var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();

            return unixDateTime;
        }


        public async Task<string> Get(string timestamp)
        {

            long unixTimestamp = ConvertDatetimeToUnixTimeStamp(DateTime.Now);
            string APIURL = $"v1/satellites/25544/positions?timestamps={unixTimestamp}";
            var response = await _httpClient.GetAsync(APIURL);


            var jsonResult = await response.Content.ReadAsStringAsync();

            //var landingSite = new 
            //{
            //    Name = "Europe",
            //    xCoordinate = "123124125",
            //    yCoordinate = 203423842
            //};

           

            // Deserialize response
            var spaceStationList = JsonSerializer.Deserialize<List<SpaceStation>>(jsonResult);
            var spaceStation = spaceStationList.First();
            
            




           
            return await response.Content.ReadAsStringAsync();
         }


    }
}
