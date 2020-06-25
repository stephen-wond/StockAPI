using AlertService.Supervisors;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlertService.Workers
{
    public class RefreshSymbolsWorker : BackgroundService
    {
        private readonly ILogger<RefreshSymbolsWorker> _logger;
        private readonly ISymbolSupervisor _symbolSupervisor;

        public RefreshSymbolsWorker(ILogger<RefreshSymbolsWorker> logger, ISymbolSupervisor symbolSupervisor)
        {
            _symbolSupervisor = symbolSupervisor;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _symbolSupervisor.UpdateSymbolsTable();
                //if any values in the old list that are not present in the new list
                //remove the stock from portfolios
                //alert user that the stock has been removed and may have changed
                //remove the symbol from the DB

                //Console.WriteLine(_companySupervisor.GetCompanyDetails("HAL"));
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(360000, stoppingToken);
            }
        }
    }
}
