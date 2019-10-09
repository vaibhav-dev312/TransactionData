using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace TransactionData.Common
{
    public static class HTTPClientFactory
    {
        public static string apiUrl = ConfigurationManager.AppSettings[Constants.API_URL];
        public static async Task<HttpResponseMessage> APIGetAsync(string requestUri, HttpRequestMessage request = null, string accessToken = null, string baseURL = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = !string.IsNullOrEmpty(baseURL) ? new Uri(baseURL) : new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_JSON));
                return await client.GetAsync(requestUri);
            }
        }

        public static async Task<HttpResponseMessage> APIPostAsync<TModel>(string requestUri, TModel model, HttpRequestMessage request = null, string accessToken = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.Timeout = TimeSpan.FromMilliseconds(30 * 1000);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_JSON));
                var jsonObject = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonObject, Encoding.UTF8, Constants.MediaType_JSON);

                return await client.PostAsync(requestUri, content);
            }
        }

        
        public static async Task<string> APIPostAsyncJson<TModel>(string requestUri, TModel model, HttpRequestMessage request = null, string accessToken = null)
        {
            var response = await APIPostAsync(requestUri, model, request, accessToken);
            string data = response.Content.ReadAsStringAsync().Result;
            return data;
        }
    }
}