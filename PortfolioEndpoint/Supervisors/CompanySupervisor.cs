using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelsLibrary.OutputModels;
using Newtonsoft.Json;
using PortfolioEndpoint.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioEndpoint.Supervisors
{
    public class CompanySupervisor : ICompanySupervisor
    {
        private readonly IConfiguration _config;
        private readonly PortfolioEndpointContext _context;
        private CompanyDetail _companyDetail;

        public CompanySupervisor(IConfiguration config, PortfolioEndpointContext context)
        {
            _config = config;
            _context = context;
            _companyDetail = new CompanyDetail();
        }

        public async Task<string> GetCompanyDetails(string companyName)
        {
            var ticker = await GetCompanyTicker(companyName);

            var domain = _config["StockAPI:Finnhub:apiEndpoint"];
            var apiToken = _config["StockAPI:Finnhub:apiToken"];

            var profilePayload = SharedHelper.GetResponsePayload($"{domain}stock/profile2?symbol={ticker}&token={apiToken}");
            var quotePayload = SharedHelper.GetResponsePayload($"{domain}quote?symbol={ticker}&token={apiToken}");
            var targetPricePayload = SharedHelper.GetResponsePayload($"{domain}stock/price-target?symbol={ticker}&token={apiToken}");
            var reccomendationPayload = SharedHelper.GetResponsePayload($"{domain}stock/recommendation?symbol={ticker}&token={apiToken}");

            var formattedPayload = ConfigureCompanyDetails(profilePayload, quotePayload, targetPricePayload, reccomendationPayload);

            return formattedPayload;
        }

        private async Task<string> GetCompanyTicker(string companyName)
        {
            var symbol = await _context.Symbols.
                Where(x => x.Name == companyName)
                .FirstOrDefaultAsync();

            return symbol.Ticker;
        }

        private string ConfigureCompanyDetails(string profilePayload, string quotePayload, string targetPricePayload, string reccomendationPayload)
        {
            dynamic d = JsonConvert.DeserializeObject(profilePayload);
            _companyDetail.Name = d.name;
            _companyDetail.Ticker = d.ticker;
            _companyDetail.Currency = d.currency;
            if (d.finnhubIndustry != "")
            {
                _companyDetail.Industry = d.finnhubIndustry;
            }
            _companyDetail.Exchange = d.exchange;

            dynamic q = JsonConvert.DeserializeObject(quotePayload);
            _companyDetail.CurrentPrice = q.c;

            dynamic t = JsonConvert.DeserializeObject(targetPricePayload);
            _companyDetail.TargetPrice = t.targetMean;

            dynamic r = JsonConvert.DeserializeObject(reccomendationPayload);
            _companyDetail.Recommend = r[0];

            return _companyDetail.ToString();
        }
    }
}
