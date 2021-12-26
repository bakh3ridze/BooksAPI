using BooksAPI.Data.Entities;
using BooksAPI.Repository.AuthorRepository.Commands;
using BooksAPI.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.SDK2.AuthorHttpClient
{
    public class AuthorHttpClient : IAuthorHttpClient
    {
        private HttpClient _httpClient;

        public AuthorHttpClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BookHttpClient");
        }
        public async Task<IEnumerable<DetailedAuthor>> GetAllDetailed()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DetailedAuthor>>(_httpClient.BaseAddress + "/Author/GetAllDetailed");
        }
        public async Task<DetailedAuthor> GetDetailedById(int Id)
        {
            return await _httpClient.GetFromJsonAsync<DetailedAuthor>(_httpClient.BaseAddress + $"/Author/Detailed/{Id}");
        }
        public async Task Create(CreateAuthorCommand command)
        {
            await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + "/Author/Create", command);
        }
        public async Task Update(int Id, UpdateAuthorCommand command)
        {
            await _httpClient.PutAsJsonAsync(_httpClient.BaseAddress + $"/Author/Update/{Id}", command);
        }
        public async Task RemoveById(int Id)
        {
            await _httpClient.DeleteAsync(_httpClient.BaseAddress + $"/Author/Delete/{Id}");
        }
    }
}
