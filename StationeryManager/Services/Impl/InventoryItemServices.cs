using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;

namespace StationeryManager.Services.Impl
{
    public class InventoryItemServices : IInventoryItemServices
    {
        private readonly HttpClient _httpClient;
        public InventoryItemServices(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<List<InventoryItemModel>> GetAllByTransactionIdAsync(string transactionId)
        {
            var result = await _httpClient.GetAsync($"api/inventory-items/{transactionId}");
            if (result.IsSuccessStatusCode)
            {
                var items = await result.Content.ReadFromJsonAsync<List<InventoryItemModel>>();
                return items ?? [];
            }
            return [];
        }
    }
}
