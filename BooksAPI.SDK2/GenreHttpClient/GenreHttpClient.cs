using BooksAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.SDK_.GenreHttpClient
{
    public class GenreHttpClient : IGenreHttpClient
    {
        private HttpClient _httpClient;
        public GenreHttpClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BookHttpClient");
        }
        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Genre>>(_httpClient.BaseAddress + "/Genre/GetAll");
        }
    }
}
