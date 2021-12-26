using BooksAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.SDK2.CountryHttpClient
{
    public class CountryHttpClient : ICountryHttpClient
    {
        private HttpClient _httpClient;
        public CountryHttpClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BookHttpClient");
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Country>>(_httpClient.BaseAddress + "/Country/GetAll");
        }
    }
}
