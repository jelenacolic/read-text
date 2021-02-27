using Newtonsoft.Json;
using RESTModels;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReadTextClient.Services
{
    public class WordCounterService
    {
        private HttpClient _client; 

        public WordCounterService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Config.ServerURL);
        }
        
        public async Task<int> SendRequest(string text)
        {
            GetWordCountRequest request = new GetWordCountRequest()
            {
                Text = text
            };

            var body = JsonConvert.SerializeObject(request);
            var contentData = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _client.PostAsync("api/countwords", contentData);

            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Server request failed, status code = {responseMessage.StatusCode}");
            }
            
            GetWordCountResponse response = JsonConvert.DeserializeObject<GetWordCountResponse>(await responseMessage.Content.ReadAsStringAsync());
            return response.WordCount;

        }
    }
}
