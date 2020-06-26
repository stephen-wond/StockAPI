using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace StockConsole
{
    public class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("1075170285:AAFAxmvzjjlBc2MG4rbRqzhSs1fVYmLrkrg");
        static void Main(string[] args)
        {
            try
            {
                //webhooks
                //bot.OnMessage += ReadTelegramMessage;
                //bot.StartReceiving();
                //Console.ReadLine();
                //bot.StopReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private static void ReadTelegramMessage(object sender, MessageEventArgs e)
        {
            var companyList = GetCompanyList();
            try
            {
                User user = new User
                {
                    Id = e.Message.From.Id,
                    FirstName = e.Message.From.FirstName,
                    LastName = e.Message.From.LastName
                };

                if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    var msg = "";
                    //send message to LUIS
                    var luisResponse = CallToLUIS(e.Message.Text);


                    switch (luisResponse.prediction.topIntent.Value)
                    {
                        case "getCompanyDetails":
                            msg = GetCompanyDetails(luisResponse);
                            break;
                        default:
                            break;
                    }

                    bot.SendTextMessageAsync(e.Message.Chat.Id, msg, disableWebPagePreview: true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }


        private static string GetCompanyDetails(dynamic input)
        {
            //get company entity from luis response 
            string luisCompany = input.prediction.entities.Company[0];

            //look up company from luis entity
            var ticker = GetTicker(luisCompany);

            //if more than one ticker then ask the question of which one - to the keyboard

            var companyProfile = CallProfile(ticker);

            return companyProfile;
        }

        private static string GetTicker(string luisCompany)
        {
            var companyList = GetCompanyList();

            var matchedCompany = new List<dynamic>();

            foreach (var company in companyList)
            {
                string description = company.description;
                if (description.Contains(luisCompany, StringComparison.OrdinalIgnoreCase))
                {
                    matchedCompany.Add(company);
                }
                string ticker = company.symbol;
                if (ticker.Equals(luisCompany, StringComparison.OrdinalIgnoreCase))
                {
                    matchedCompany.Insert(0, company);
                }
            }

            return matchedCompany.First().symbol;
        }

        private static List<dynamic> GetCompanyList()
        {
            //need to send thid to db and cache, 
            //refresh DB once a week, refresh cache once a day?
            var companyList = new List<dynamic>();
            companyList.AddRange(CallSymbol("US"));
            companyList.AddRange(CallSymbol("L"));

            return companyList;
        }
        private static List<dynamic> CallSymbol(string exchange)
        {
            Task<string> result = GetResponseString($"https://finnhub.io/api/v1/stock/symbol?exchange={exchange}&token=bre1e4vrh5rcbvtnn600");
            var jsonResult = result.Result;
            var jsonObject = JsonConvert.DeserializeObject<List<dynamic>>(jsonResult);
            return jsonObject;
        }
        private static double CallQuote(string ticker)
        {
            Task<string> result = GetResponseString($"https://finnhub.io/api/v1/quote?symbol={ticker}&token=bre1e4vrh5rcbvtnn600");
            var jsonResult = result.Result;
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonResult);
            return jsonObject.c;
        }
        private static string CallProfile(string ticker)
        {
            Task<string> result = GetResponseString($"https://finnhub.io/api/v1/stock/profile2?symbol={ticker}&token=bre1e4vrh5rcbvtnn600");
            var jsonResult = result.Result;
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonResult);
            return jsonObject.ToString();
        }
        private static dynamic CallToLUIS(string msg)
        {
            Task<string> result = GetResponseString($"https://westus.api.cognitive.microsoft.com/luis/prediction/v3.0/apps/fc5ab44b-59d2-4c14-9d52-060c417cadc8/slots/staging/predict?subscription-key=355b00232b1247369ebc0288dfd3c416&verbose=true&show-all-intents=false&log=true&query={msg}");
            var jsonResult = result.Result;
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonResult);
            return jsonObject;
        }
        private static string PostToTelegram(string msg)
        {
            msg = WebUtility.UrlEncode(msg);
            Task<string> result = GetResponseString($"https://api.telegram.org/bot1075170285:AAEHDszXRqzzjVS8glWEf1Mb00vpyhJWqGQ/sendMessage?chat_id=1168355673&text={msg}&parse_mode=HTML&disable_web_page_preview=true");
            var jsonResult = result.Result;
            var jsonObject = JsonConvert.DeserializeObject<string>(jsonResult);
            return jsonObject;
        }

        private static async Task<string> GetResponseString(string query)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                return contents;
            }
            else
            {
                throw new HttpRequestException($"{response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}
