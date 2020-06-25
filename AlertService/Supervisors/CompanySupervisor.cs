using AlertService.OutputModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AlertService.Supervisors
{
    public class CompanySupervisor : ICompanySupervisor
    {
        private readonly IConfiguration _config;
        private CompanyDetail _companyDetail;

        public CompanySupervisor(IConfiguration config)
        {
            _config = config;
            _companyDetail = new CompanyDetail();
        }

        public string GetCompanyDetails(string ticker)
        {
            var domain = _config["stockEndpoint"];
            var apiToken = _config["apiToken"];

            var profilePayload = SharedHelper.GetResponsePayload($"{domain}stock/profile2?symbol={ticker}&token={apiToken}");
            var quotePayload = SharedHelper.GetResponsePayload($"{domain}quote?symbol={ticker}&token={apiToken}");
            var targetPricePayload = SharedHelper.GetResponsePayload($"{domain}stock/price-target?symbol={ticker}&token={apiToken}");
            var reccomendationPayload = SharedHelper.GetResponsePayload($"{domain}stock/recommendation?symbol={ticker}&token={apiToken}");

            var formattedPayload = ConfigureCompanyDetails(profilePayload, quotePayload, targetPricePayload, reccomendationPayload);

            return formattedPayload;
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
