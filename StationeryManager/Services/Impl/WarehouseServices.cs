using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public class WarehouseServices : IWarehouseServices
    {
        private readonly HttpClient _httpClient;
        public WarehouseServices(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<List<WarehouseModel>> GetAllAsync(FilterModel filter)
        {
            var query = string.Empty;
            if (filter != null)
            {
                var parameters = new Dictionary<string, string?>
                {
                    { "limit", filter.Limit.ToString() },
                    { "page", filter.Page.ToString() }
                };

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                query = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
            }
            var result = await _httpClient.GetAsync($"api/warehouses?{query}");
            if (result.IsSuccessStatusCode)
            {
                var warehouses = await result.Content.ReadFromJsonAsync<List<WarehouseModel>>();
                return warehouses ?? [];
            }
            return [];
        }

        public async Task<WarehouseModel?> GetByIdAsync(string id)
        {
            var result = await _httpClient.GetAsync($"api/warehouses/{id}");
            if (result.IsSuccessStatusCode)
            {
                var warehouse = await result.Content.ReadFromJsonAsync<WarehouseModel>();
                return warehouse;
            }
            return null;
        }
    }
}
