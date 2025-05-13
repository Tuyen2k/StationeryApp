using System.Security.Principal;
using StationeryManager.Util;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly HttpClient _httpClient;
        public CategoryServices(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<int> CountAllAsync(FilterModel? filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/categories/count", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var categories = await result.Content.ReadFromJsonAsync<int>();
                return categories;
            }
            return 0;
        }

        public async Task<bool> CreateAsync(CategoryRequest category)
        {
            var result = await _httpClient.PostAsJsonAsync("api/categories", category);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/categories/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<CategoryModel>> GetAllAsync(FilterModel? filter)
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
            var result = await _httpClient.GetAsync($"api/categories?{query}");
            if (result.IsSuccessStatusCode)
            {
                var categories = await result.Content.ReadFromJsonAsync<List<CategoryModel>>();
                return categories ?? [];
            }
            return [];
        }

        public async Task<CategoryModel?> GetByIdAsync(string id)
        {
            var result = await _httpClient.GetAsync($"api/categories/{id}");
            if (result.IsSuccessStatusCode)
            {
                var category = await result.Content.ReadFromJsonAsync<CategoryModel>();
                return category;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string id, CategoryRequest category)
        {
            var result = await _httpClient.PatchAsJsonAsync($"api/categories/{id}", category);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
