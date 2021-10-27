using BooksAPI.Data.Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Sdk
{
    public class HTTPHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<Options> _options;
        public HTTPHelper(IHttpClientFactory httpClientFactory, IOptions<Options> options)
        {
            _httpClient = httpClientFactory.CreateClient();
            _options = options;
            _httpClient.BaseAddress = new Uri(options.Value.URL);
        }
        public async Task<T> Get<T>(string methodURL)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, methodURL);
            var response = await _httpClient.SendAsync(httpRequestMessage);
            string result = await response.Content.ReadAsStringAsync();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var TResult = JsonConvert.DeserializeObject<T>(result);
                return TResult;
            }
            else
            {
                throw new Exception();
            }
        }
    }
    public class Options
    {
        public string URL { get; set; }
        public int ClientKey { get; set; }
        public int ClientSecret { get; set; }
    }
}
