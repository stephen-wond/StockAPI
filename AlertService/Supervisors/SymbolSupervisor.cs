using Microsoft.Extensions.Configuration;
using ModelsLibrary.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AlertService.Supervisors

{
    public class SymbolSupervisor : ISymbolSupervisor
    {
        private readonly IConfiguration _config;

        public SymbolSupervisor(IConfiguration config)
        {
            _config = config;
        }

        public void UpdateSymbolsTable()
        {
            var newSymbols = GetLatestSymbols();
            //var newSymbols = new List<Symbol>();
            //extract to DAL
            //var oldSymbols = await _context.Symbols.ToListAsync();
            var oldSymbols = GetStoredSymbols();

            //var newNotOld = newSymbols.Except(oldSymbols);
            var newNotOld = newSymbols.Where(l2 => !oldSymbols.Any(l1 => l1.Name == l2.Name));//.ToList();
            var oldNotNew = oldSymbols.Where(l2 => !newSymbols.Any(l1 => l1.Name == l2.Name));//.ToList();

            PostSymbols(newNotOld);
            //await _context.Symbols.AddRangeAsync(newNotOld);
            //await _context.SaveChangesAsync();
            //log

            //var oldNotNew = oldSymbols.Except(newSymbols);
            //Console.WriteLine(oldNotNew.FirstOrDefault().ToString());
            //send message to user
            //log
        }

        private IEnumerable<Symbol> GetLatestSymbols()
        {
            var domain = _config["finnhubEndpoint"];
            var apiToken = _config["apiToken"];

            var companyList = new List<Symbol>();

            companyList.AddRange(GetLastestExchangeSymbols(domain, "US", apiToken));
            companyList.AddRange(GetLastestExchangeSymbols(domain, "L", apiToken));

            return companyList;
        }

        private IEnumerable<Symbol> GetStoredSymbols()
        {
            var domain = _config["localApiEndpoint"];
            var companyList = SharedHelper.GetResponsePayload($"{domain}api/Symbols");
            var listPayload = JsonConvert.DeserializeObject<IEnumerable<Symbol>>(companyList);

            return listPayload;
        }

        private bool PostSymbols(IEnumerable<Symbol> symbolsList)
        {
            var domain = _config["localApiEndpoint"];
            var url = $"{domain}api/Symbols/PostSymbols";

            var jsonPayload = JsonConvert.SerializeObject(symbolsList);

            var success = SharedHelper.PostJsonPayload(url, jsonPayload);

            return success;
        }

        private IEnumerable<Symbol> GetLastestExchangeSymbols(string domain, string exchange, string apiToken)
        {
            var symbolPayload = SharedHelper.GetResponsePayload($"{domain}stock/symbol?exchange={exchange}&token={apiToken}");
            var listPayload = JsonConvert.DeserializeObject<IEnumerable<Symbol>>(symbolPayload);
            return listPayload;
        }
    }
}
