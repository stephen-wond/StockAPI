using Microsoft.Extensions.Configuration;
using ModelsLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AlertService.Supervisors
{
    public class PriceChangeSupervisor : IPriceChangeSupervisor
    {
        private readonly IConfiguration _config;

        public PriceChangeSupervisor(IConfiguration config)
        {
            _config = config;
        }

        public void FindPriceChangeAlerts()
        {
            var allStocks = GetStoredSymbols();

            var groupedList = allStocks.GroupBy(s => s.Symbol);

            foreach (var stock in groupedList)
            {
                var price = GetLastestPrice(stock.Key.Ticker);

                var stocks = allStocks.Where(s => s.SymbolId == stock.Key.SymbolId);

                foreach (var s in stocks)
                {
                    if (Math.Abs(s.LastAlertPrice - price) > (s.LastAlertPrice * 0.05))
                    {

                        //call local api and get the user detiails
                        Console.WriteLine($"{s.UserId} need to let this person know that {s.Symbol} is now {price} from {s.LastAlertPrice}");
                        //send alert to telegram with call to chatbot app

                        s.LastAlertPrice = price;
                        PostSymbols(s);
                        //update lastAlertPrice - put to stocks table
                    }
                }
            }
        }

        private IEnumerable<Stock> GetStoredSymbols()
        {
            var domain = _config["localApiEndpoint"];
            var stockList = SharedHelper.GetResponsePayload($"{domain}api/Stocks");
            var listPayload = JsonConvert.DeserializeObject<IEnumerable<Stock>>(stockList);

            return listPayload;
        }
        private double GetLastestPrice(string ticker)
        {
            var domain = _config["finnhubEndpoint"];
            var apiToken = _config["apiToken"];

            var quoteResult = SharedHelper.GetResponsePayload($"{domain}quote?symbol={ticker}&token={apiToken}");
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(quoteResult);
            return jsonObject.c;
        }

        private bool PostSymbols(Stock stock)
        {
            var domain = _config["localApiEndpoint"];
            var url = $"{domain}api/Stocks/{stock.StockId}";

            var jsonPayload = JsonConvert.SerializeObject(stock);

            var success = SharedHelper.PutJsonPayload(url, jsonPayload);

            return success;
        }
    }
}