using Sundown2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Services
{
    public interface ILandingForecastService
    {
        Task<LandingTime> Get();

    }
}
