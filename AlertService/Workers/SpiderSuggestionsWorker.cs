using AlertService.Supervisors;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlertService.Workers
{
    public class SpiderSuggestionsWorker : BackgroundService
    {
        private readonly ILogger<SpiderSuggestionsWorker> _logger;
        private readonly ICompanySupervisor _companySupervisor;

        public SpiderSuggestionsWorker(ILogger<SpiderSuggestionsWorker> logger, ICompanySupervisor companySupervisor)
        {
            _companySupervisor = companySupervisor;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //runs over the weekend when markets are closed
                //looks over all markets and finds those that are undervalued or reccommended 
                //find top 3 and send them to all users with company details and news stories

                //api limit is 60 calls per min
                //keep track and if hit 30 calls in the min then set a timer to wait for everything


                _logger.LogInformation("Worker1 running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
