using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PortfolioAPI.Models;

namespace PortfolioAPI
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly PortfolioContext _context;

        public Worker(PortfolioContext context, ILogger<Worker> logger)
        {
            _context = context;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _context.Stocks.ToList();
            while (!stoppingToken.IsCancellationRequested)
            {

                //grab all tickers from stocks, is active
                var stocks = _context.Stocks
                    .Where(s => s.IsActive == true)
                    .ToList();

                foreach (var stock in stocks)
                {
                    Console.WriteLine(stock.User.FirstName);
                }

                //

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
