using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Webapplication.Services
{
    public class HttpClient
    {
        private HttpClient _httpClient;
        private HttpClient GetClient()
        {
            if(_httpClient == null)
            {
                _httpClient = new HttpClient();
            }
            return _httpClient;
        }

        public async Task<TResult> SendAsync<TResult>(string route, HttpMethod method, string jsonContent = null) where TResult : class
        {
            try
            {
                var client = GetClient();

                var message = new HttpRequestMessage();

                if (!string.IsNullOrEmpty(jsonContent))
                {
                    message.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                message.Method = method;
                message.RequestUri = new Uri(route);

                var result = await client.SendAsync(message);

                if (!result.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await result.Content.ReadAsStringAsync(); 
                var resultObj = JsonConvert.D
            }
        }

    }
}
