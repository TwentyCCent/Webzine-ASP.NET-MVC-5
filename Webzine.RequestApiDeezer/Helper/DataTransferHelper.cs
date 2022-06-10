// <copyright file="DataTransferHelper.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.RequestApiDeezer.Helper
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

        /// <summary>
        /// Méthode SendAsync générique aux différentes méthodes HTTP.
        /// </summary>
        /// <typeparam name="TResult">Type à désérialiser.</typeparam>
        /// <param name="route">URL.</param>
        /// <param name="method">GET, PUT, POST, DELETE.</param>
        /// <param name="jsonContent">Contenu pour les méthode POST.</param>
        /// <returns>Objet de type T désérialisé.</returns>
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

        private HttpClient GetClient()
        {
            if (this.httpClient == null)
            {
                this.httpClient = new HttpClient();
            }

            return this.httpClient;
        }
    }
}
