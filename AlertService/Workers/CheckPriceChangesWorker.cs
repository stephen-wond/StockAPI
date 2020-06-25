using AlertService.Supervisors;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlertService.Workers
{
    public class CheckPriceChangesWorker : BackgroundService
    {
        private readonly ILogger<CheckPriceChangesWorker> _logger;
        private readonly IPriceChangeSupervisor _priceChangeSupervisor;

        public CheckPriceChangesWorker(ILogger<CheckPriceChangesWorker> logger, IPriceChangeSupervisor priceChangeSupervisor)
        {
            _priceChangeSupervisor = priceChangeSupervisor;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //get all stocks/portfolio listings from DB
                _priceChangeSupervisor.FindPriceChangeAlerts();
                //group by symbol
                //get price for each symbol
                //loop thru stocks listing for that symbol (each user that has that stock)
                //if latest price is within 5% of target then send user message and deactivate/offer new price point
                //if latest price has jumped +- 5% from lastAlertPrice then send user message, update lastAlertPrice

                _logger.LogInformation("Worker1 running at: {time}", DateTimeOffset.Now);
                await Task.Delay(120000, stoppingToken);
            }
        }
    }
}
