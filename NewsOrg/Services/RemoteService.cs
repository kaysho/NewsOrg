using System;
using System.Net.Http;
using System.Threading.Tasks;
using NewsOrg.Response;
using Newtonsoft.Json;

namespace NewsOrg.Services
{
    public class RemoteService
    {
        HttpClient httpClient;
        public RemoteService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{App.BackendUrl}/");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.TokenSettings);
        }

        public async Task<NewsReponse> AllNewsResponseAsync()
        {
            var newsResponse = new NewsReponse();
            var response = await httpClient.GetAsync($"top-headlines?country=us&apiKey=1e0e1afcc8544b1cbe5a13146366e1eb").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                newsResponse = JsonConvert.DeserializeObject<NewsReponse>(result);

                return newsResponse;
            }
            else
            {
                return new NewsReponse { Articles = null};
            }
        }
    }
}
