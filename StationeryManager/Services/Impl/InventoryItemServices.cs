using StationeryManager.Util;
using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services.Impl
{
    public class InventoryItemServices : IInventoryItemServices
    {
        private readonly HttpClient _httpClient;
        public InventoryItemServices(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<int> CountAllAsync(InventoryItemFilterModel filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.ProductId))
                {
                    parameters.Add("productId", filter.ProductId);
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/inventory-items/count", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var count = await result.Content.ReadFromJsonAsync<int>();
                return count;
            }
            return 0;
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
