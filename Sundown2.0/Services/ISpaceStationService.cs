using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Services
{
    public interface ISpaceStationService
    {
       Task<IExtremaEnumerable<KeyValuePair<string, double>>> Get(string timestamp);
    }
}
