using BooksAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BooksAPI.Repository.Models;
using BooksAPI.Repository.BookRepository.Commands;

namespace BooksAPI.SDK2.BookHttpClient
{
    public class BookHttpClient : IBookHttpClient
    {
        private HttpClient _httpClient;

        public BookHttpClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BookHttpClient");
        }

        public async Task Create(CreateBookCommand command)
        {
            await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + $"/Book/Create", command);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Book>>(_httpClient.BaseAddress + "/Book/GetAll");
        }

        public async Task<IEnumerable<DetailedBook>> GetAllDetailed()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DetailedBook>>(_httpClient.BaseAddress + "/Book/GetAllDetailed");
        }

        public async Task<IEnumerable<DetailedBook>> GetAllNotDeletedDetaileds()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DetailedBook>>(_httpClient.BaseAddress + $"/Book/GetAllNotDeletedDetaileds");
        }

        public async Task<DetailedBook> GetDetailedById(int Id)
        {
            return await _httpClient.GetFromJsonAsync<DetailedBook>(_httpClient.BaseAddress + $"/Book/Detailed/{Id}");
        }
        public async Task<IEnumerable<DetailedBook>> GetDetailedsByAuthorId(int Id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DetailedBook>>(_httpClient.BaseAddress + $"/Book/GetDetailedsByAuthorId/{Id}");
        }
        public async Task RemoveById(int Id)
        {
            await _httpClient.DeleteAsync(_httpClient.BaseAddress + $"/Book/Delete/{Id}");
        }

        public async Task Update(int Id, UpdateBookCommand command)
        {
            await _httpClient.PutAsJsonAsync(_httpClient.BaseAddress + $"/Book/Update/{Id}", command);
        }
    }
}
