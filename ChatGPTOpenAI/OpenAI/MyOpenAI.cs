using ChatGPTOpenAI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTOpenAI.OpenAI
{

    public class MyOpenAI
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        //open ai Key
        //
        public MyOpenAI(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<string> GenerateText(string prompt, string engineId, int maxTokens, double temperature)
        {
            try
            {
                var requestBody = new
                {
                    model = engineId,
                    messages = new[] { new { role = "user", content = prompt } }
                };

                var json = JsonConvert.SerializeObject(requestBody);
                Console.WriteLine(json);

                var response = await _httpClient.PostAsJsonAsync($"https://api.openai.com/v1/chat/completions", requestBody);
                response.EnsureSuccessStatusCode();
                
                // Response 내용을 deserialize 하기 위해 Newtonsoft.Json 라이브러리 사용
                var responseContent = await response.Content.ReadAsStringAsync();
                var chatCompletion = JsonConvert.DeserializeObject<ChatCompletion>(responseContent);
                var content = chatCompletion?.Choices?.FirstOrDefault()?.Message?.Content;

                
                return content;
            }
            catch (HttpRequestException ex)
            {
                if (ex.InnerException is not null)
                {
                    Console.WriteLine($"HTTP Request Exception: {ex.Message}, Inner Exception: {ex.InnerException.Message}");
                }
                else
                {
                    Console.WriteLine($"HTTP Request Exception: {ex.Message}");
                }
                throw;
            }

          
        }
    }

}