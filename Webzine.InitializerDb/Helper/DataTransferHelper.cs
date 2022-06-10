namespace Webzine.InitializerDb.Helper
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Http client proposant une méthode SendAsync générique aux différentes méthodes Http. 
    /// </summary>
    public class DataTransferHelper
    {
        private HttpClient httpClient;

        private HttpClient GetClient()
        {
            if (this.httpClient == null)
            {
                this.httpClient = new HttpClient();
            }

            return this.httpClient;
        }

        public async Task<TResult> SendAsync<TResult>(string route, HttpMethod method, string jsonContent = null)
            where TResult : class
        {
            try
            {
                var client = this.GetClient();

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

                var resultObj = JsonConvert.DeserializeObject<TResult>(content);

                return resultObj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
