using System.Net.Http.Json;
using ToDo.ClientSide2.Entities;

namespace ToDo.ClientSide2.HttpServices
{
    public class ToDoHttpService
    {
        private readonly HttpClient _httpClient;

        public ToDoHttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<ToDoItemDto>> GetAllAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<List<ToDoItemDto>>("/api/todo");
            return items;
        }

        public async Task<ToDoItemDto> AddAsync(ToDoItemDto item)
        {
            var response = await _httpClient.PostAsJsonAsync<ToDoItemDto>("/api/todo", item);
            //check
            return await response.Content.ReadFromJsonAsync<ToDoItemDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/todo/{id}");
        }
    }
}
