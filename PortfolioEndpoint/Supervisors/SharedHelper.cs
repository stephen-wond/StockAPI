using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioEndpoint.Supervisors
{
    public class SharedHelper
    {
        public static string GetResponsePayload(string url)
        {
            Task<string> result = GetEndpoint(url);
            var jsonResult = result.Result;
            return jsonResult;
        }

        public static bool PostJsonPayload(string url, string jsonPayload)
        {
            Task<bool> result = PostEndpoint(url, jsonPayload);
            var boolResult = result.Result;
            return boolResult;
        }

        public static bool PutJsonPayload(string url, string jsonPayload)
        {
            Task<bool> result = PutEndpoint(url, jsonPayload);
            var boolResult = result.Result;
            return boolResult;
        }

        private static async Task<string> GetEndpoint(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();
                    return contents;
                }
                else
                {
                    throw new HttpRequestException($"{response.StatusCode} - {response.ReasonPhrase}: {url}");
                }
            }
        }

        private static async Task<bool> PostEndpoint(string url, string jsonPayload)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(url, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new HttpRequestException($"{response.StatusCode} - {response.ReasonPhrase}: {url}");
                }
            }
        }

        private static async Task<bool> PutEndpoint(string url, string jsonPayload)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(url, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new HttpRequestException($"{response.StatusCode} - {response.ReasonPhrase}: {url}");
                }
            }
        }
    }
}
