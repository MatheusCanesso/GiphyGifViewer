using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace GiphyGifViewer
{
    internal class GiphyService
    {
        private readonly string apiKey = "bN4Sepd2jEzO4MJ8XxSp7fGwhbn3QCvW"; // Substitua pela sua chave de API
        private readonly string baseUrl = "https://api.giphy.com/v1/gifs/search";

        public async Task<string> GetGifUrlAsync(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{baseUrl}?api_key={apiKey}&q={query}&limit=1";
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (!response.IsSuccessStatusCode)
                    return null;

                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(jsonResponse);
                return json["data"]?[0]?["images"]?["original"]?["url"]?.ToString();
            }
        }
    }
}
