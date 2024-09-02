using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace SizeTracker.Parsers
{
    internal class JoomParser : SiteParserBase
    {
        public static string SiteName { get; } = "joom";
        
        //private static string AccessToken;

        public override string[] GetAvailableSizes(string url)
        {
            var initialUrl = "https://www.joom.com/ru/";
            var tokenUrl = "https://www.joom.com/tokens/init?";
            var productApiUrl = "https://api.joom.com/1.1/products/";
            var productId = url.Substring(url.LastIndexOf('/') + 1);

            using (HttpClient client = new HttpClient())
            {
                var initialResponse = client.GetAsync(initialUrl).Result;
                initialResponse.EnsureSuccessStatusCode();

                var accessToken = GetToken(client, tokenUrl);

                return GetAvailableSizesFromAccessToken(client, productApiUrl, productId, accessToken);
            }
        }

        static string GetToken(HttpClient client, string tokenUrl)
        {
            client.DefaultRequestHeaders.Clear();
        
            var tokenResponse = client.PostAsync(tokenUrl, null).Result;
            tokenResponse.EnsureSuccessStatusCode();
        
            var tokenResponseBody = tokenResponse.Content.ReadAsStringAsync().Result;
            var jsonResponse = JObject.Parse(tokenResponseBody);
        
            return jsonResponse["payload"]["accessToken"].ToString();
        }

        static string[] GetAvailableSizesFromAccessToken(HttpClient client, string productApiUrl, string productId, string accessToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var productResponse = client.GetAsync(productApiUrl + productId).Result;
            productResponse.EnsureSuccessStatusCode();

            var productResponseBody = productResponse.Content.ReadAsStringAsync().Result;

            var jsonResponse = JObject.Parse(productResponseBody);
            var a = jsonResponse["payload"]["variants"].Count();
            var sizes = new string[a]; //TODO: придумать названия i и a 
            for (int i = 0; i < a; i++)
            {
                sizes[i] = jsonResponse["payload"]["variants"][i]["size"].ToString();
            }
            return sizes;
        }
    }
}
