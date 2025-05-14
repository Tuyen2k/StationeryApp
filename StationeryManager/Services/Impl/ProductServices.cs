using StationeryManager.Util;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public class ProductServices : IProductServices {
        private readonly HttpClient _httpClient;

        public ProductServices(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<int> CountAllAsync(ProductFilterModel? filter) {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                if (!string.IsNullOrEmpty(filter.SubCategoryId))
                {
                    parameters.Add("subCategoryId", filter.SubCategoryId);
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/products/count", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var count = await result.Content.ReadFromJsonAsync<int>();
                return count;
            }
            return 0;
        }

        public async Task<bool> CreateAsync(ProductRequest product) {
            var result = await _httpClient.PostAsJsonAsync("api/products", product);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string id) {
            var result = await _httpClient.DeleteAsync($"api/products/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ProductModel>> GetAllAsync(ProductFilterModel? filter) {
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

                if (!string.IsNullOrEmpty(filter.SubCategoryId))
                {
                    parameters.Add("subCategoryId", filter.SubCategoryId);
                }

                query = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
            }
            var result = await _httpClient.GetAsync($"api/products?{query}");
            if (result.IsSuccessStatusCode)
            {
                var products = await result.Content.ReadFromJsonAsync<List<ProductModel>>();
                return products ?? [];
            }
            return [];
        }

        public async Task<ProductModel?> GetByIdAsync(string id) {
            var result = await _httpClient.GetAsync($"api/products/{id}");
            if (result.IsSuccessStatusCode)
            {
                var product = await result.Content.ReadFromJsonAsync<ProductModel>();
                return product;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string id, ProductRequest product) {
            var result = await _httpClient.PatchAsJsonAsync($"api/products/{id}", product);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
