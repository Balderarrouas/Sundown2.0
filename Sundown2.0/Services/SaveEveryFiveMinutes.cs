using Coravel.Invocable;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Sundown2._0.Services
{
    public class SaveEveryFiveMinutes : IInvocable
    {
        private readonly ILogger<SaveEveryFiveMinutes> _logger;
        private readonly ISpaceStationService _spaceStationService;

        public SaveEveryFiveMinutes(ILogger<SaveEveryFiveMinutes> logger, ISpaceStationService spaceStationService)
        {
            _logger = logger;
            _spaceStationService = spaceStationService;
        }


        public async Task Invoke()
        {
            await _spaceStationService.Get();
        }


    }
}
