using System.Net.Http.Json;
using ToDo.ClientSide2.Entities;

namespace ToDo.ClientSide2.HttpServices
{
    public class UserHttpService
    {
        private readonly HttpClient _httpClient;

        public UserHttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<List<User>>("/api/user");
            return items;
        }
    }
}
