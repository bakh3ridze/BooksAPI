using BooksAPI.Repository.AuthRepository.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.SDK_.AuthHttpClient
{
    public class AuthHttpClient : IAuthHttpClient
    {
        private HttpClient _httpClient;
        public AuthHttpClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BookHttpClient");
        }
        public async Task<string> Authenticate(AuthCommand command)
        {
            HttpResponseMessage response =  await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + "/Auth/Authenticate", command);
            var tokenData = await response.Content.ReadAsStringAsync();
            var token = JObject.Parse(tokenData)["token"].ToString();
            int a = 7;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return token;
        }
    }
}
