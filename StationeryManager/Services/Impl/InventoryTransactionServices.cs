using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public class InventoryTransactionServices : IInventoryTransactionServices
    {
        private readonly HttpClient _httpClient;

        public InventoryTransactionServices(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(InventoryTransactionRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/inventories", request);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/inventories/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ProductStockModel>> GetAllAsync(InventoryTransactionFilterModel filter)
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
            var result = await _httpClient.GetAsync($"api/inventories?{query}");
            if (result.IsSuccessStatusCode)
            {
                var inventories = await result.Content.ReadFromJsonAsync<List<ProductStockModel>>();
                return inventories ?? [];
            }
            return [];
        }

        public async Task<List<InventoryTransactionModel>> GetAlls(InventoryTransactionFilterModel filter)
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

                if (!string.IsNullOrEmpty(filter.TransactionType))
                {
                    parameters.Add("transactionType", filter.TransactionType);
                }

                query = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
            }
            var result = await _httpClient.GetAsync($"api/inventories?{query}");
            if (result.IsSuccessStatusCode)
            {
                var inventories = await result.Content.ReadFromJsonAsync<List<InventoryTransactionModel>>();
                return inventories ?? [];
            }
            return [];
        }

        public async Task<InventoryTransactionModel?> GetById(string id)
        {
            var result = await _httpClient.GetAsync($"api/inventories/{id}");
            if (result.IsSuccessStatusCode)
            {
                var inventory = await result.Content.ReadFromJsonAsync<InventoryTransactionModel>();
                return inventory;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string id, InventoryTransactionRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/inventories/{id}", request);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
